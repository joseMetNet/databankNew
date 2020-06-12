using System;
using System.Web.Mvc;
using System.Data;
using DATABANK.App_Data;
using System.Security.Cryptography;
using System.IO;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Linq;
using Newtonsoft.Json;
using System.Security.Permissions;

namespace DATABANK.Controllers
{
    public class AdministradorController : Controller
    {

        public ActionResult Dashboard()
        {
            Session["alve"] = "dash";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
            {
                return RedirectToAction("Logout");
            }

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            return View("/Views/administrador/Dashboard.cshtml");
        }
        public ActionResult Logout()
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            data.removeSession(Convert.ToInt32(Session["idEmpleado"]));
            Session.RemoveAll();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult usuarios()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataUsuario();
            ViewBag.usuario = dt.Rows;
            return View("/Views/administrador/partialsUsuario/table.cshtml");
        }
        public ActionResult createUsuario()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dt = data.ObtenerData("SP_getPerfil");
            ViewBag.ListaPerfil = dt.Rows;


            return View("/Views/administrador/partialsUsuario/create.cshtml");
        }
        public ActionResult saveUsuario(Models.usuarios model)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            var nomaas = Request.Files;
            for (var i = 0; i < nomaas.Count; i++)
            {
                if (nomaas[i].ContentLength > 0)
                {
                    string FileName = Path.GetFileNameWithoutExtension(nomaas[i].FileName);
                    FileName = NombreImagen();
                    string FileExtension = Path.GetExtension(nomaas[i].FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                    string UploadPath = System.Web.HttpContext.Current.Server.MapPath("/Content/uploads/");
                    string stringimg = "/Content/uploads/" + FileName;
                    nomaas[i].SaveAs(UploadPath + FileName);
                    model.imagen = "/Content/uploads/" + FileName;
                }
            }
            string respuesta = "";
            CredencialesDeAcceso acceso = new CredencialesDeAcceso();
            string contrasena = acceso.creacionContrasena();
            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.GenerateKey();
            myRijndael.GenerateIV();
            string usuario = acceso.creacionUsuario(model.nombre, model.apellido).ToLower();
            model.usuario = usuario;
            Byte[] contrasenaEncriptada = acceso.EncryptStringToBytes(contrasena, myRijndael.Key, myRijndael.IV);

            DataTable dt = data.saveUsuario(model, contrasenaEncriptada, myRijndael.Key, myRijndael.IV);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count == 1)
            {
                if (row["respuesta"].ToString() == "0")
                {
                    TempData["type"] = "error";
                    TempData["title"] = "Error";
                    TempData["message"] = "El usuario con el email " + model.email + "   ya se encuentra registrado en el sistema.";
                    RedirectToAction("createUsuario"); 
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (model.idUsuario == 0)
                        {
                            TempData["message"] = "Usuario creado con éxito.";
                            EnviarCorreos correoCreacion = new EnviarCorreos();
                            string bodyCorreo = correoCreacion.ArmarCorreoUsuarioNuevo(model.nombre, model.apellido, model.usuario, contrasena, model.telefono);
                            correoCreacion.EnviarCorreo(model.email, "Usuario Nuevo", "natalia.bernal@metnet.co", bodyCorreo, "natalia.bernal@metnet.co", "natalia.bernal@metnet.co", "Mercedes23725001", "");
                            Session["message"] = "Usted va a recibir un correo  con sus credenciales de acceso. Haga clic en el correo para consultar a su usuario. Si no ve el correo , verifique otros lugares.";
                            Session["title"] = "Muy Bien.";
                            Session["type"] = "success";
                        }
                    }
                    else
                    {
                        TempData["message"] = "Problemas al crear el usuario, intente nuevamente.";
                        TempData["title"] = "Error.";
                        TempData["type"] = "error";
                    }
                }
            }
            if (model.idUsuario == 0)
                return RedirectToAction("usuarios");
            else
                return RedirectToAction("usuarios");
        }
        public ActionResult saveUsuarioUpdate(Models.usuarios model)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();

            CredencialesDeAcceso acceso = new CredencialesDeAcceso();
            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.GenerateKey();
            myRijndael.GenerateIV();
            if (Request["passwordstring"].ToString() != "")
            {
                model.passwordEncriptado = acceso.EncryptStringToBytes(Request["passwordstring"], myRijndael.Key, myRijndael.IV);
            }
            var nomaas = Request.Files;
            for (var i = 0; i < nomaas.Count; i++)
            {
                if (nomaas[i].ContentLength > 0)
                {
                    string FileName = Path.GetFileNameWithoutExtension(nomaas[i].FileName);
                    FileName = NombreImagen();
                    string FileExtension = Path.GetExtension(nomaas[i].FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                    string UploadPath = System.Web.HttpContext.Current.Server.MapPath("/Content/uploads/");
                    string stringimg = "/Content/uploads/" + FileName;
                    nomaas[i].SaveAs(UploadPath + FileName);
                    model.imagen = "/Content/uploads/" + FileName;
                }
            }

            if (model.imagen == null)
            {
                DataTable dm = data.getDataUsuario(model.idUsuario);
                model.imagen = dm.Rows[0]["imagen"].ToString();
            }
            DataTable dt = data.saveUsuarioUpdate(model, myRijndael.Key, myRijndael.IV);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count == 1)
            {
                if (row["respuesta"].ToString() != "0")
                {
                    if (dt.Rows.Count > 0)
                    {
                        TempData["message"] = "Usuario Modificado con éxito.";
                        TempData["title"] = "Muy Bien.";
                        TempData["type"] = "success";
                    }
                    else
                    {
                        TempData["message"] = "Problemas al modificar el usuario, intente nuevamente.";
                        TempData["title"] = "Error.";
                        TempData["type"] = "error";
                    }

                }
            }

            if (model.idUsuario == 0)
                return RedirectToAction("usuarios");
            else
                return RedirectToAction("usuarios");
        }
        public ActionResult editUsuario(int id)
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataUsuario(id);
            ViewBag.usuario = dt.Rows[0];

            dt = data.ObtenerData("SP_getPerfil");
            ViewBag.ListaPerfil = dt.Rows;
            dt = data.getEstado(1);
            ViewBag.ListaEstado = dt.Rows;
            CredencialesDeAcceso acceso = new CredencialesDeAcceso();
            ViewBag.contrasenaFinal = acceso.DecryptStringFromBytes(ViewBag.usuario["contrasena"], ViewBag.usuario["pKEY"], ViewBag.usuario["pIV"]);
            return View("/Views/administrador/partialsUsuario/edit.cshtml");
        }
        public ActionResult bodegas()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataBodega();
            ViewBag.bodega = dt.Rows;
            return View("/Views/administrador/partialsBodega/table.cshtml");
        }
        public ActionResult createBodega()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dt = data.getDataProyecto();
            ViewBag.ListaProyecto = dt.Rows;
            dt = data.getDataDepartamento();
            ViewBag.ListaDepartamento = dt.Rows;
            return View("/Views/administrador/partialsBodega/create.cshtml");
        }
        public ActionResult saveBodega(Models.Bodega model)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            var nomaas = Request.Files;
            for (var i = 0; i < nomaas.Count; i++)
            {
                if (nomaas[i].ContentLength > 0)
                {
                    string FileName = Path.GetFileNameWithoutExtension(nomaas[i].FileName);
                    FileName = NombreImagen();
                    string FileExtension = Path.GetExtension(nomaas[i].FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                    string UploadPath = System.Web.HttpContext.Current.Server.MapPath("/Content/uploads/");
                    string stringimg = "/Content/uploads/" + FileName;
                    nomaas[i].SaveAs(UploadPath + FileName);
                    model.imagen = "/Content/uploads/" + FileName;
                }
            }

            DataTable dt = data.saveBodega(model);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count == 1)
            {
                if (row["respuesta"].ToString() == "0")
                {
                    TempData["type"] = "error";
                    TempData["title"] = "Error";
                    TempData["message"] = "La bodega con el codigo " + model.codigo + "   ya se encuentra registrado en el sistema.";
                    RedirectToAction("createBodega");
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (model.idBodega == 0)
                        {
                            TempData["message"] = "Bodega creada con éxito.";
                            TempData["title"] = "Muy Bien.";
                            TempData["type"] = "success";
                        }
                    }
                    else
                    {
                        TempData["message"] = "Problemas al crear la bodega, intente nuevamente.";
                        TempData["title"] = "Error.";
                        TempData["type"] = "error";
                    }
                }
            }
      
            if (model.idBodega == 0)
                return RedirectToAction("bodegas");
            else
                return RedirectToAction("bodegas");
        }
        public ActionResult editBodega(int id)
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dt = data.getDataBodega(id);
            ViewBag.bodega = dt.Rows[0];
            dt = data.getEstado(1);
            ViewBag.ListaEstado = dt.Rows;
            dt = data.getDataProyecto();
            ViewBag.ListaProyecto = dt.Rows;
            dt = data.getDataDepartamento();
            ViewBag.ListaDepartamento = dt.Rows;
            return View("/Views/administrador/partialsBodega/edit.cshtml");
        }
        public ActionResult CargarInfo()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getMaterialesBodega(0);
            ViewBag.ListaMateriales = dt.Rows;
            dt = data.getErrores(0);
            ViewBag.ListaErrores = dt.Rows;
            dt = data.getEstado(1);
            ViewBag.ListaEstado = dt.Rows;
            dt = data.getDataProyecto();
            ViewBag.ListaProyecto = dt.Rows;
            return View("/Views/administrador/partialsInventario/table.cshtml");
        }
        public ActionResult saveBodegaUpdate(Models.Bodega model)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            var nomaas = Request.Files;
            for (var i = 0; i < nomaas.Count; i++)
            {
                if (nomaas[i].ContentLength > 0)
                {
                    string FileName = Path.GetFileNameWithoutExtension(nomaas[i].FileName);
                    FileName = NombreImagen();
                    string FileExtension = Path.GetExtension(nomaas[i].FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                    string UploadPath = System.Web.HttpContext.Current.Server.MapPath("/Content/uploads/");
                    string stringimg = "/Content/uploads/" + FileName;
                    nomaas[i].SaveAs(UploadPath + FileName);
                    model.imagen = "/Content/uploads/" + FileName;
                }
            }

            if(model.imagen == null)
            {
                DataTable tp = data.getDataBodega(model.idBodega);
                model.imagen = tp.Rows[0]["imagen"].ToString();
            }
            DataTable dt = data.saveBodegaUpdate(model);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count == 1)
            {
                if (row["respuesta"].ToString() != "0")
                {
                    if (dt.Rows.Count > 0)
                    {
                        TempData["message"] = "Bodega Modificada con éxito.";
                        TempData["title"] = "Muy Bien.";
                        TempData["type"] = "success";
                    }
                    else
                    {
                        TempData["message"] = "Problemas al modificar la bodega, intente nuevamente.";
                        TempData["title"] = "Error.";
                        TempData["type"] = "error";
                    }

                }
            }

            if (model.idBodega == 0)
                return RedirectToAction("bodegas");
            else
                return RedirectToAction("bodegas");
        }
        public ActionResult Productos()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataProducto();
            ViewBag.producto = dt.Rows;
            return View("/Views/administrador/partialsProducto/table.cshtml");
        }
        public ActionResult createProducto()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dt= data.ObtenerData("SP_getBodega");
            ViewBag.ListaBodega = dt.Rows;
            dt = data.ObtenerData("SP_getUnidadMedida");
            ViewBag.ListaUnidadMedida = dt.Rows;
            dt = data.ObtenerData("SP_getUsuario");
            ViewBag.ListaUsuario = dt.Rows;
            return View("/Views/administrador/partialsProducto/create.cshtml");
        }
        
        public ActionResult editProducto(int id)
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataProducto(id);
            ViewBag.Producto = dt.Rows[0];
            dt = data.ObtenerData("SP_getUnidadMedida");
            ViewBag.ListaUnidadMedida = dt.Rows;
            dt = data.ObtenerData("SP_getBodega");
            ViewBag.ListaBodega = dt.Rows;
            dt = data.getEstado(1);
            ViewBag.ListaEstado = dt.Rows;
            dt = data.ObtenerData("SP_getUsuario");
            ViewBag.ListaUsuario = dt.Rows;

            return View("/Views/administrador/partialsProducto/edit.cshtml");
        }
        public ActionResult saveProductoUpdate(Models.Producto model)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();

            DataTable dt = data.saveProductoUpdate(model);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count == 1)
            {
                if (row["respuesta"].ToString() != "0")
                {
                    if (dt.Rows.Count > 0)
                    {
                        TempData["message"] = "Producto Modificado con éxito.";
                        TempData["title"] = "Muy Bien.";
                        TempData["type"] = "success";
                    }
                    else
                    {
                        TempData["message"] = "Problemas al modificar el producto, intente nuevamente.";
                        TempData["title"] = "Error.";
                        TempData["type"] = "error";
                    }

                }
            }

            if (model.idBodega == 0)
                return RedirectToAction("Productos");
            else
                return RedirectToAction("Productos");
        }
        public ActionResult Proyectos()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataProyecto();
            ViewBag.proyecto = dt.Rows;
            dt = data.ObtenerData("SP_getLineasTotales");
            ViewBag.TL = dt.Rows;
            dt = data.ObtenerData("SP_getLineasContadas");
            ViewBag.LC = dt.Rows;
            return View("/Views/administrador/partialsProyecto/table.cshtml");
        }
        public ActionResult createProyectos()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();

            DataTable dt = data.ObtenerData("SP_getcliente");
            ViewBag.ListaCliente = dt.Rows;
            dt = data.ObtenerData("SP_getProyectoUsuario");
            ViewBag.ListaUsuario = dt.Rows;
            dt = data.ObtenerData("SP_getSucursal");
            ViewBag.ListaSucursal = dt.Rows;
            dt = data.getDataDepartamento();
            ViewBag.ListaDepartamento = dt.Rows;
            return View("/Views/administrador/partialsProyecto/create.cshtml");
        }

        public ActionResult saveProyecto(Models.Proyecto model)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            var nomaas = Request.Files;
            for (var i = 0; i < nomaas.Count; i++)
            {
                if (nomaas[i].ContentLength > 0)
                {
                    string FileName = Path.GetFileNameWithoutExtension(nomaas[i].FileName);
                    FileName = NombreImagen();
                    string FileExtension = Path.GetExtension(nomaas[i].FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                    string UploadPath = System.Web.HttpContext.Current.Server.MapPath("/Content/uploads/");
                    string stringimg = "/Content/uploads/" + FileName;
                    nomaas[i].SaveAs(UploadPath + FileName);
                    model.Logo = "/Content/uploads/" + FileName;
                }
            }

            DataTable dt = data.saveProyecto(model);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows.Count > 0)
                {
                    if (model.idProyecto == 0)
                    {
                        TempData["message"] = "Proyecto creado con éxito.";
                        TempData["title"] = "Muy Bien.";
                        TempData["type"] = "success";
                    }
                }
                
            }
            if (model.idProyecto == 0)
                return RedirectToAction("Proyectos");
            else
                return RedirectToAction("Proyectos");
        }

        public ActionResult editProyecto(int id)
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataProyecto(id);
            ViewBag.Proyecto = dt.Rows[0];
            dt = data.getDataProyectoUsuario(id);
            ViewBag.ListaProyectoUsuario = dt.Rows;
            dt = data.ObtenerData("SP_getProyectoUsuario");
            ViewBag.ListaUsuario = dt.Rows;

            dt = data.getEstado(1);
            ViewBag.ListaEstado = dt.Rows;
            dt = data.ObtenerData("SP_getcliente");
            ViewBag.ListaCliente = dt.Rows;
            dt = data.ObtenerData("SP_getSucursal");
            ViewBag.ListaSucursal = dt.Rows;
            dt = data.getDataDepartamento();
            ViewBag.ListaDepartamento = dt.Rows;
            return View("/Views/administrador/partialsProyecto/edit.cshtml");
        }
        
        public ActionResult saveProyectoUpdate(Models.Proyecto model)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            var nomaas = Request.Files;
            for (var i = 0; i < nomaas.Count; i++)
            {
                if (nomaas[i].ContentLength > 0)
                {
                    string FileName = Path.GetFileNameWithoutExtension(nomaas[i].FileName);
                    FileName = NombreImagen();
                    string FileExtension = Path.GetExtension(nomaas[i].FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                    string UploadPath = System.Web.HttpContext.Current.Server.MapPath("/Content/uploads/");
                    string stringimg = "/Content/uploads/" + FileName;
                    nomaas[i].SaveAs(UploadPath + FileName);
                    model.Logo = "/Content/uploads/" + FileName;
                }
            }
            if (model.Logo == null)
            {
                DataTable dm = data.getDataProyecto(model.idProyecto);
                model.Logo = dm.Rows[0]["logo"].ToString();
            }
            DataTable dt = data.saveProyectoUpdate(model);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count == 1)
            {
                if (row["respuesta"].ToString() != "0")
                {
                    if (dt.Rows.Count > 0)
                    {
                        TempData["message"] = "Proyecto Modificado con éxito.";
                        TempData["title"] = "Muy Bien.";
                        TempData["type"] = "success";
                    }
                    else
                    {
                        TempData["message"] = "Problemas al modificar el proyecto, intente nuevamente.";
                        TempData["title"] = "Error.";
                        TempData["type"] = "error";
                    }

                }
            }

            if (model.idProyecto == 0)
                return RedirectToAction("Proyectos");
            else
                return RedirectToAction("Proyectos");
        }
        public ActionResult saveProyectoUsuario(Models.Proyecto model)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;
            int idUsuario = 0;
            if (model.NombreUsuario != null)
            {
                string respuesta = "";
                CredencialesDeAcceso acceso = new CredencialesDeAcceso();
                string contrasena = acceso.creacionContrasena();
                RijndaelManaged myRijndael = new RijndaelManaged();
                myRijndael.GenerateKey();
                myRijndael.GenerateIV();
                string usuario = acceso.creacionUsuario(model.NombreUsuario, model.ApellidoUsuario).ToLower();
                model.Usuario = usuario;
                Byte[] contrasenaEncriptada = acceso.EncryptStringToBytes(contrasena, myRijndael.Key, myRijndael.IV);

                dd = data.saveUsuarioProyecto(model, contrasenaEncriptada, myRijndael.Key, myRijndael.IV);
                DataRow rows = dd.Rows[0];
                if (dd.Rows.Count == 1)
                {
                    if (rows["respuesta"].ToString() == "0")
                    {
                        TempData["type"] = "error";
                        TempData["title"] = "Error";
                        TempData["message"] = "El usuario con el email " + model.EmailUsuario + "   ya se encuentra registrado en el sistema.";
                        RedirectToAction("editProyecto", new { @id = model.idProyecto });
                    }
                    else
                    {
                        if (dd.Rows.Count > 0)
                        {
                            
                            EnviarCorreos correoCreacion = new EnviarCorreos();
                            string bodyCorreo = correoCreacion.ArmarCorreoUsuarioNuevo(model.NombreUsuario, model.ApellidoUsuario, model.Usuario, contrasena, model.TelefonoUsuario);
                            correoCreacion.EnviarCorreo(model.EmailUsuario, "Usuario Nuevo", "natalia.bernal@metnet.co", bodyCorreo, "natalia.bernal@metnet.co", "natalia.bernal@metnet.co", "Mercedes23725001", "");
                            idUsuario = Convert.ToInt32(dd.Rows[0]["IdUsuario"]);
                            Session["message"] = "Usted va a recibir un correo  con sus credenciales de acceso. Haga clic en el correo para consultar a su usuario. Si no ve el correo , verifique otros lugares.";
                            Session["title"] = "Muy Bien.";
                            DataTable dt = data.saveProyectoUsuario(model, idUsuario);
                            DataRow row = dt.Rows[0];
                            if (dt.Rows.Count == 1)
                            {
                                if (row["respuesta"].ToString() != "0")
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        TempData["message"] = "Usuario agregado con éxito.";
                                        TempData["title"] = "Muy Bien.";
                                        TempData["type"] = "success";
                                    }
                                }
                                else
                                {
                                    TempData["message"] = "El usuario ya se encuentra en este proyecto.";
                                    TempData["title"] = "Error.";
                                    TempData["type"] = "error";
                                }
                            }

                        }
                        else
                        {
                            TempData["message"] = "Problemas al crear el usuario, intente nuevamente.";
                            TempData["title"] = "Error.";
                            TempData["type"] = "error";
                        }
                    }
                }

            }
            else
            {
                if(model.idUsuario != 0)
                {
                    DataTable dt = data.saveProyectoUsuario(model, model.idUsuario);
                    DataRow row = dt.Rows[0];
                    if (dt.Rows.Count == 1)
                    {
                        if (row["respuesta"].ToString() != "0")
                        {
                            if (dt.Rows.Count > 0)
                            {
                                TempData["message"] = "Usuario agregado con éxito.";
                                TempData["title"] = "Muy Bien.";
                                TempData["type"] = "success";
                            }
                        }
                        else
                        {
                            TempData["message"] = "El usuario ya se encuentra en este proyecto.";
                            TempData["title"] = "Error.";
                            TempData["type"] = "error";
                        }
                    }
                }
            }
            if (model.idProyecto == 0)
                return RedirectToAction("editProyecto", new { @id = model.idProyecto });
            else
                return RedirectToAction("editProyecto", new { @id = model.idProyecto });
        }
        public ActionResult Inventario()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataInventario();
            ViewBag.inventario = dt.Rows;
            return View("/Views/administrador/partialsInventario/table.cshtml");
        }
        public ActionResult createInventario()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
                       
            DataTable dt = data.getDataProyecto();
            ViewBag.ListaProyecto = dt.Rows;
            dt = data.ObtenerData("SP_getBodega");
            ViewBag.ListaBodega = dt.Rows;
            dt = data.getDataProducto();
            ViewBag.ListaProducto = dt.Rows;
            return View("/Views/administrador/partialsInventario/create.cshtml");
        }
        
        public ActionResult editInventario(int id)
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getDataInventario(id);
            ViewBag.Inventario = dt.Rows[0];
            dt = data.getDataProyecto();
            ViewBag.ListaProyecto = dt.Rows;
            dt = data.ObtenerData("SP_getBodega");
            ViewBag.ListaBodega = dt.Rows;
            dt = data.getDataProducto();
            ViewBag.ListaProducto = dt.Rows;
            dt = data.getEstado(1);
            ViewBag.ListaEstado = dt.Rows;
            return View("/Views/administrador/partialsInventario/edit.cshtml");
        }
        
        public ActionResult cargarInventario()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();

            DataTable dt = data.ObtenerData("sp_getTemporal");
            ViewBag.temporal = dt.Rows;
            dt = data.getDataProyecto();
            ViewBag.ListaProyecto = dt.Rows;
            return View("/Views/administrador/partialsInventario/CargarInventario.cshtml");
        }
        
        public ActionResult SubirMateriales(object sender, EventArgs e, Models.Proyecto model)
        {
            try
            {
                ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
                var nomaas = Request.Files;
                string[] docs = Request["fileDoc[]"].Split(',');

                if (nomaas.Count > 0)
                {
                    string FileName = Path.GetFileNameWithoutExtension(nomaas[0].FileName).Replace("+", "");
                    string FileExtension = Path.GetExtension(nomaas[0].FileName);
                    nomaas[0].SaveAs(System.Web.HttpContext.Current.Server.MapPath("/Content/uploads/") + nomaas[0].FileName);
                }


                using (OleDbConnection conn = new OleDbConnection())
                {
                    DataTable dt = new DataTable();
                    DataTable dtfinal = new DataTable();
                    dtfinal.Columns.Add(new DataColumn("PROYECTO", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("BODEGA", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("CENTRO", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("UBICACION", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("SERIAL", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("UM", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("DESCRIPCION", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("QTY", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("PRECIO", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("RUTA", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("OPERARIO", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("NO_CONTEO", typeof(string)));
                    dtfinal.Columns.Add(new DataColumn("CORTE", typeof(DateTime)));
                    DataRow dr = null;
                    string Import_FileName = Server.MapPath("/Content/uploads/") + nomaas[0].FileName;

                    string fileExtension = Path.GetExtension(nomaas[0].FileName);
                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        if (fileExtension == ".xls")
                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                        if (fileExtension == ".xlsx")
                            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                        using (OleDbCommand comm = new OleDbCommand())
                        {
                            comm.CommandText = "Select * from [" + "Hoja1" + "$]";

                            comm.Connection = conn;

                            using (OleDbDataAdapter da = new OleDbDataAdapter())
                            {
                                da.SelectCommand = comm;
                                da.Fill(dt);
                                int variable = 1;
                                int contaTotal = dt.Columns.Count;
                                int idProyecto = 0;
                                int idBodega = 0;
                                string Centro = "";
                                string Ubicacion = "";
                                string Codigo = "";
                                string Serial = "";
                                int idUnidadMedida = 0;
                                string Descripcion = "";
                                int QTY = 0;
                                string Precio = "";
                                int Ruta = 0;
                                int idOperario = 0;
                                int Conteo = 0;
                                int valoresCargados = 0;
                                string observacion = "";
                                int Linea = 0;
                                DataTable errores = new DataTable();
                                errores.Columns.Add(new DataColumn("PROYECTO", typeof(string)));
                                errores.Columns.Add(new DataColumn("BODEGA", typeof(string)));
                                errores.Columns.Add(new DataColumn("CENTRO", typeof(string)));
                                errores.Columns.Add(new DataColumn("UBICACION", typeof(string)));
                                errores.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                                errores.Columns.Add(new DataColumn("SERIAL", typeof(string)));
                                errores.Columns.Add(new DataColumn("UM", typeof(string)));
                                errores.Columns.Add(new DataColumn("DESCRIPCION", typeof(string)));
                                errores.Columns.Add(new DataColumn("QTY", typeof(string)));
                                errores.Columns.Add(new DataColumn("PRECIO", typeof(string)));
                                errores.Columns.Add(new DataColumn("RUTA", typeof(string)));
                                errores.Columns.Add(new DataColumn("OPERARIO", typeof(string)));
                                errores.Columns.Add(new DataColumn("NO_CONTEO", typeof(string)));
                                errores.Columns.Add(new DataColumn("CORTE", typeof(DateTime)));
                                errores.Columns.Add(new DataColumn("LINEA", typeof(string)));
                                errores.Columns.Add(new DataColumn("OBSERVACION", typeof(string)));
                                DataRow error = null;
                                foreach (DataRow rows in dt.Rows)
                                {
                                    if (model.idProyecto != 0)
                                    {
                                        idProyecto = model.idProyecto;
                                    }
                                    if (rows["BODEGA"].ToString() != "")
                                    {
                                        DataTable dn = data.ObtenerBodega(rows["BODEGA"].ToString());
                                        
                                        if (dn.Rows.Count > 0)
                                        {
                                            DataRow row = dn.Rows[0];
                                            idBodega = (Convert.ToInt32(row["idBodega"]));
                                        }
                                        else
                                        {
                                            idBodega = 2;
                                            Linea = variable;
                                            observacion = "No se encontro la BODEGA";
                                        }
                                    }
                                    else
                                    {
                                        idBodega = 2;
                                        Linea = variable;
                                        observacion = "Campo BODEGA vacio";
                                    }

                                    if (rows["CENTRO"].ToString() != "")
                                    {
                                        Centro = rows["CENTRO"].ToString();
                                    }

                                    if (rows["UBICACION"].ToString() != "")
                                    {
                                        Ubicacion = rows["UBICACION"].ToString();
                                    }
                                    else
                                    {
                                        Linea = variable;
                                        observacion = observacion + ", Campo UBICACIÓN vacio";
                                    }
                                    if (rows["CODIGO"].ToString() != "")
                                    {
                                        Codigo = rows["CODIGO"].ToString();
                                    }
                                    else
                                    {
                                        Linea = variable;
                                        observacion = observacion + ", Campo CÓDIGO vacio";
                                    }

                                    if (rows["SERIAL"].ToString() != "")
                                    {
                                        Serial = rows["SERIAL"].ToString();
                                    }

                                    if (rows["UM"].ToString() != "")
                                    {
                                        DataTable dn = data.ObtenerUnidadMedida(rows["UM"].ToString());
                                        DataRow row = dn.Rows[0];
                                        if (dn.Rows.Count > 0)
                                        {
                                            idUnidadMedida = (Convert.ToInt32(row["idUnidadMedida"])); 
                                        }
                                    }
                                    else
                                    {
                                        Linea = variable;
                                        observacion = observacion + ", Campo UM vacio";
                                    }

                                    if (rows["DESCRIPCION"].ToString() != "")
                                    {
                                        Descripcion = rows["DESCRIPCION"].ToString();
                                    }
                                    else
                                    {
                                        Linea = variable;
                                        observacion = observacion + ", Campo DESCRIPCIÓN vacio";
                                    }
                                    if (rows["QTY"].ToString() != "")
                                    {
                                        QTY = (Convert.ToInt32(rows["QTY"]));
                                    }
                                    else
                                    {
                                        Linea = variable;
                                        observacion = observacion + ", Campo QTY vacio";
                                    }
                                    if (rows["PRECIO"].ToString() != "")
                                    {
                                        Precio = rows["PRECIO"].ToString();
                                    }
                                    else
                                    {
                                        Linea = variable;
                                        observacion = observacion + ", Campo PRECIO vacio";
                                    }
                                    if (rows["RUTA"].ToString() != "")
                                    {
                                        Ruta = (Convert.ToInt32(rows["RUTA"]));
                                    }
                                    if (rows["OPERARIO"].ToString() != "")
                                    {
                                        DataTable dn = data.ObtenerOperario(rows["OPERARIO"].ToString());
                                        
                                        if (dn.Rows.Count > 0)
                                        {
                                            DataRow row = dn.Rows[0];
                                            idOperario = (Convert.ToInt32(row["idUsuario"]));
                                        }
                                        else
                                        {
                                            idOperario = 6;
                                            Linea = variable;
                                            observacion = observacion + ", No se encontro el OPERARIO";
                                        }
                                    }
                                    else
                                    {
                                        idOperario = 6;
                                        Linea = variable;
                                        observacion = observacion + ", Campo OPERARIO vacio";
                                    }
                                    if (rows["NO_CONTEO"].ToString() != "")
                                    {
                                        Conteo = (Convert.ToInt32(rows["NO_CONTEO"]));
                                    }
                                    else
                                    {
                                        Linea = variable;
                                        observacion = observacion + ", Campo NO_CONTEO vacio";
                                    }

                                    if(observacion != "")
                                    {
                                        error = errores.NewRow();
                                        error["PROYECTO"] = idProyecto;
                                        error["BODEGA"] = idBodega;
                                        error["CENTRO"] = Centro;
                                        error["UBICACION"] = Ubicacion;
                                        error["CODIGO"] = Codigo;
                                        error["SERIAL"] = Serial;
                                        error["UM"] = idUnidadMedida;
                                        error["DESCRIPCION"] = Descripcion;
                                        error["QTY"] = QTY;
                                        error["PRECIO"] = Precio;
                                        error["RUTA"] = Ruta;
                                        error["OPERARIO"] = idOperario;
                                        error["NO_CONTEO"] = Conteo;
                                        error["CORTE"] = DateTime.Now;
                                        error["LINEA"] = Linea;
                                        error["OBSERVACION"] = observacion;
                                        errores.Rows.Add(error);
                                    }
                                    else
                                    {
                                        dr = dtfinal.NewRow();
                                        dr["PROYECTO"] = idProyecto;
                                        dr["BODEGA"] = idBodega;
                                        dr["CENTRO"] = Centro;
                                        dr["UBICACION"] = Ubicacion;
                                        dr["CODIGO"] = Codigo;
                                        dr["SERIAL"] = Serial;
                                        dr["UM"] = idUnidadMedida;
                                        dr["DESCRIPCION"] = Descripcion;
                                        dr["QTY"] = QTY;
                                        dr["PRECIO"] = Precio;
                                        dr["RUTA"] = Ruta;
                                        dr["OPERARIO"] = idOperario;
                                        dr["NO_CONTEO"] = Conteo;
                                        dr["CORTE"] = DateTime.Now;
                                        dtfinal.Rows.Add(dr);

                                    }
                                    variable++;
                                    observacion = "";

                                }
                                if(errores.Rows.Count > 0 )
                                {
                                    DataTable eliminar = data.eliminarTemporalErrores(model.idProyecto);
                                    DataTable de = data.CargarErrores(errores);
                                    errores.Rows.Clear();

                                }
                                else if(dtfinal.Rows.Count > 0)
                                {
                                    DataTable eliminar = data.eliminarTemporalErrores(model.idProyecto);
                                    DataTable tm = data.CargarMaterialesTemporal(dtfinal);
                                    valoresCargados = valoresCargados + dtfinal.Rows.Count;
                                    DataTable cargar = data.CargarTablaMateriales(model.idProyecto);
                                    dtfinal.Rows.Clear();
                                }
                                else
                                {
                                    TempData["message"] = "La plantilla no cuenta con el formato correcto, intente de nuevo";
                                    TempData["title"] = "Error.";
                                    TempData["type"] = "error";
                                    return RedirectToAction("CargarInfo");
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new System.ArgumentOutOfRangeException("index parameter is out of range.", ex);
            }
            return RedirectToAction("MostraInfo", new {@id = model.idProyecto});
        }
        public ActionResult MostraInfo(int id)
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getMaterialesBodega(id);
            ViewBag.ListaMateriales = dt.Rows;
            dt = data.getErrores(id);
            ViewBag.ListaErrores = dt.Rows;
            dt = data.getEstado(1);
            ViewBag.ListaEstado = dt.Rows;
            dt = data.getDataProyecto();
            ViewBag.ListaProyecto = dt.Rows;
            return View("/Views/administrador/partialsInventario/table.cshtml");
        }
        public ActionResult ListaMaterialesInspeccion()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;
            dd = data.getDataProducto();
            ViewBag.materiales = dd.Rows;
            dd = data.getDataProyecto();
            ViewBag.proyecto = dd.Rows;

            return View("/Views/administrador/partialsInspeccion/Inspeccion.cshtml");
        }
        public ActionResult crearInspeccion(int id)
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            int idProyecto = 0;
            int idUsuario = 0;
            DataTable dd = null;
            if(id == 0)
            {
                idProyecto = Convert.ToInt32(Request["idProyecto"]);
            }
            else
            {
                idProyecto = id;
            }

            if (idProyecto > 0)
            {

                idUsuario = Convert.ToInt32(Session["idUsuario"]);
                dd = data.getProyectoBodega(idProyecto,idUsuario);
                DataRow row = null;
                if (dd.Rows.Count > 0)
                {
                    row = dd.Rows[0];
                }
                if (dd.Rows.Count > 0)
                {
                    if (row["respuesta"].ToString() != "0")
                    {
                        DataTable dt = data.getDataProducto(Convert.ToInt32(dd.Rows[0]["idProducto"]));
                        ViewBag.Producto = dt.Rows[0];
                        dt = data.ObtenerData("SP_getUnidadMedida");
                        ViewBag.ListaUnidadMedida = dt.Rows;
                        dt = data.ObtenerData("SP_getBodega");
                        ViewBag.ListaBodega = dt.Rows;
                        dt = data.getEstado(2);
                        ViewBag.ListaEstado = dt.Rows;
                        dt = data.ObtenerData("SP_getCategoria");
                        ViewBag.ListaCategoria = dt.Rows;
                        dt = data.getListaInspección(idProyecto, idUsuario);
                        ViewBag.ListaRuta = dt.Rows;
                        return View("/Views/administrador/partialsInspeccion/create.cshtml");
                    }
                    else
                    {
                        return RedirectToAction("ListaMaterialesInspeccion");
                    }
                }
                else
                {
                    if (dd.Rows.Count > 0)
                    {
                        if (row["respuesta"].ToString() == "0")
                        {
                            TempData["message"] = "no se encuentra asignado a este inventario.";
                            TempData["title"] = "Este Usuario";
                            TempData["type"] = "error";
                            return RedirectToAction("ListaMaterialesInspeccion");
                        }
                        else
                        {
                            DataTable dm = data.ActualizarEstadoProducto(idProyecto);
                            TempData["message"] = "Inspección Terminada.";
                            TempData["title"] = "Muy Bien.";
                            TempData["type"] = "success";
                            return RedirectToAction("ListaInspecciones");
                        }
                    }
                    else
                    {
                        DataTable dm = data.ActualizarEstadoProducto(idProyecto);
                        TempData["message"] = "Inspección Terminada.";
                        TempData["title"] = "Muy Bien.";
                        TempData["type"] = "success";
                        return RedirectToAction("ListaInspecciones");
                    }
                }
            }
            else
            {
                return RedirectToAction("ListaMaterialesInspeccion");
            }
            
        }
        
        public ActionResult saveInspeccion(Models.Inspeccion model, int idProyecto = 0)
        {
            Session["alve"] = "config";
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable nn = null;
            int idUsuario = Convert.ToInt32(Session["idUsuario"]);
            if (model.idBodegaP != 0)
            {
                nn = data.saveProducto(idProyecto,model.idBodegaP,model.UbicacionP,model.codigoP, model.idUnidadMedidaP
                    ,model.descripcionP,model.cantidadP,idUsuario);
                if (nn.Rows.Count > 0)
                {
                    model.idProducto = Convert.ToInt32(nn.Rows[0]["idProducto"]);
                }
            }
            
            DataTable dt = data.saveInspeccion(model,idProyecto);
            DataTable dm = data.ActualizarEstadoTemporal(model.idProducto, idUsuario,6, Convert.ToInt32(model.Conteo));
            DataRow row = dt.Rows[0];
            var nomaas = Request.Files;
            int i = 0;
            for (i = 0; i < nomaas.Count; i++)
            {
                if (nomaas[i].ContentLength > 0)
                {
                    string FileName = Path.GetFileNameWithoutExtension(nomaas[i].FileName);
                    string FileExtension = Path.GetExtension(nomaas[i].FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + FileName.Trim() + FileExtension;
                    string UploadPath = System.Web.HttpContext.Current.Server.MapPath("/Content/uploads/");
                    string stringimg = "/Content/uploads/" + FileName;
                    nomaas[i].SaveAs(UploadPath + FileName);
                    if (i == 0)
                        data.saveImg(FileName, stringimg, model.idProducto, Convert.ToInt32(dt.Rows[0]["idInspeccion"]));
                    else
                        data.saveImg(FileName, stringimg, model.idProducto, Convert.ToInt32(dt.Rows[0]["idInspeccion"]));
                }
            }
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows.Count > 0)
                {
                    if (model.idProyecto == 0)
                    {
                        TempData["message"] = "Inspección creada con éxito.";
                        TempData["title"] = "Muy Bien.";
                        TempData["type"] = "success";
                    }
                }

            }
            if (model.idInspecion == 0)
                return RedirectToAction("crearInspeccion", new {@id = idProyecto});
            else
                return RedirectToAction("crearInspeccion", new { @id = idProyecto });
        }
        public ActionResult ListaInspecciones()
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dt = data.getInspeccion();
            ViewBag.inspeccion = dt.Rows;

            return View("/Views/administrador/partialsInspeccion/table.cshtml");
        }
        public ActionResult showInspeccion(int id)
        {
            Session["alve"] = "config";
            ViewBag.valos = "Config";
            if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                return RedirectToAction("Index", "Home");

            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = null;

            DataTable dt = data.getInspeccion(id);
            ViewBag.Inspeccion = dt.Rows[0];
            dt = data.ObtenerData("SP_getBodega");
            ViewBag.ListaBodega = dt.Rows;
            dt = data.ObtenerData("SP_getUnidadMedida");
            ViewBag.ListaUnidadMedida = dt.Rows;

            dt = data.getEstado(2);
            ViewBag.ListaEstado = dt.Rows; 

            dt = data.ObtenerData("SP_getCategoria");
            ViewBag.ListaCategoria = dt.Rows;

            dt = data.getImageplus(id);
            if (dt.Rows.Count > 0)
                ViewBag.image = dt.Rows;
            else
               ViewBag.image = dt.Rows;
            return View("/Views/administrador/partialsInspeccion/show.cshtml");
        }

        public string NombreImagen()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string datatabletojson(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
        public JsonResult deActivateUser(int id, int pstatus)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = data.deActivateUser(id, pstatus);
            ViewBag.result = 1;
            return Json(new { ViewBag.result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deActivateAlmacen(int id, int pstatus)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = data.deActivateAlmacen(id, pstatus);
            ViewBag.result = 1;
            return Json(new { ViewBag.result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deActivateBodega(int id, int pstatus)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = data.deActivateBodega(id, pstatus);
            ViewBag.result = 1;
            return Json(new { ViewBag.result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deActivateProyecto(int id, int pstatus)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = data.deActivateProyecto(id, pstatus);
            ViewBag.result = 1;
            return Json(new { ViewBag.result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deActivateUserProyecto(int id, int pstatus)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = data.deActivateUserProyecto(id, pstatus);
            ViewBag.result = 1;
            return Json(new { ViewBag.result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult savePermiso(int id,string t, string g, string e, string d, string im, string ex)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = data.savePermiso(id,t,g,e,d,im,ex);
            ViewBag.result = 1;
            return Json(new { ViewBag.result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deActivateInventario(int id, int pstatus)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = data.deActivateInventario(id, pstatus);
            ViewBag.result = 1;
            return Json(new { ViewBag.result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getUsuarioProyecto(int id)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dd = data.getDataBodega(id);
            DataTable dt = data.getDataProyectoUsuario(Convert.ToInt32(dd.Rows[0]["idProyecto"]));
            ViewBag.result = datatabletojson(dt);

            return Json(ViewBag.result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getDepartamentoMunicipio(int id)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            DataTable dt = data.getDepartamentoMunicipio(id);
            ViewBag.result = datatabletojson(dt);

            return Json(ViewBag.result, JsonRequestBehavior.AllowGet);
        }

    }
}