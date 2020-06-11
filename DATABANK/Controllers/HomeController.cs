using System;
using System.Web.Mvc;
using System.Data;
using DATABANK.App_Data;
using System.Security.Cryptography;

namespace DATABANK.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login(Models.Login model)
        {
            Session["idUsuario"] = null;
            Session["idPerfil"] = null;
            Session["nombre"] = null;

            if (model.usuario != null)
            {
                ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
                CredencialesDeAcceso acceso = new CredencialesDeAcceso();
                DataTable dt = data.ValidarIngresoUsuario(model.usuario, GetMACAddress().ToString());
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (Convert.ToInt32(row["idEstado"]) == 2)
                    {
                        Session["message"] = "Este nombre de usuario se encuentra inactivo, por favor comunicar al administrador.";
                    }
                    else
                    {
                        byte[] contrasena = (byte[])row["contrasena"];
                        byte[] key = (byte[])row["pKEY"];
                        byte[] iv = (byte[])row["pIV"];
                        if (contrasena.Length > 2)
                        {
                            string contrasenaFinal = acceso.DecryptStringFromBytes(contrasena, key, iv);
                            if (contrasenaFinal == model.contrasena)
                            {
                                dt = data.verifySession(Convert.ToInt32(row["idUsuario"]));
                                if (Convert.ToInt32(dt.Rows[0]["respuesta"]) == 0)
                                    Session["message"] = "Ya existe una cuenta activa, no puede acceder con la misma cuenta.";
                                else
                                {
                                    dynamic dol = null;
                                    if (dt.Rows.Count == 1)
                                        dol = dt.Rows[0];
                                    else
                                        dol = dt.Rows[1];
                                    Session["lastlogin"] = dol["dateAction"].ToString("yyyy-MM-dd HH:mm:ss");
                                    Session["idUsuario"] = row["idUsuario"].ToString();
                                    Session["idPerfil"] = row["idPerfil"].ToString();
                                    Session["imagen"] = row["imagen"].ToString();
                                    Session["nombre"] = row["nombre"].ToString();
                                    return RedirectToAction("Dashboard", "administrador");
                                }
                            }
                            else
                            {
                                Session["message"] = "Las credenciales de usuario no coinciden, verifique.";
                            }
                        }
                    }
                }
                else
                {
                    Session["message"] = "No se encontro datos de usuario con esas credenciales, por favor cree uno.";
                }
                Session["title"] = "Error";
                Session["type"] = "error";
            }
            return RedirectToAction("Index");
        }
        public ActionResult recoverPassword(Models.forgotYourPassword model)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            string respuesta = "";
            CredencialesDeAcceso acceso = new CredencialesDeAcceso();
            string contrasena = acceso.creacionContrasena();
            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.GenerateKey();
            myRijndael.GenerateIV();
            Byte[] contrasenaEncriptada = acceso.EncryptStringToBytes(contrasena, myRijndael.Key, myRijndael.IV);
            DataTable dt = data.actualizarContrasena(model.email.Trim(), contrasenaEncriptada, myRijndael.Key, myRijndael.IV);
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                string[] nombreTelefono = respuesta.Split('-');
                EnviarCorreos correoCreacion = new EnviarCorreos();
                string bodyCorreo = correoCreacion.ArmarCorreoRecuperacionContrasenaMobil(row["Nombre"].ToString(), contrasena, 0, row["telefono"].ToString());
                correoCreacion.EnviarCorreo(row["email"].ToString(), "Restablecimiento de contraseña", "natalia.bernal@metnet.co", bodyCorreo, "natalia.bernal@metnet.co", "natalia.bernal@metnet.co", "Mercedes23725001", "");
                Session["message"] = "Usted va a recibir un correo electrónico con una contraseña temporal, si no ve el correo electrónico, verifique otros lugares.";
                Session["title"] = "Muy bien";
                Session["type"] = "success";
            }
            else
            {
                Session["message"] = "El nombre de usuario no existe. por favor cree uno nuevo";
                Session["title"] = "El email no existe";
                Session["type"] = "error";
            }
            return RedirectToAction("Index");
        }
        public ActionResult forgotYourPassword()
        {
            return View();
        }
        

        public string GetMACAddress()
        {
            System.Net.NetworkInformation.NetworkInterface[] nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (System.Net.NetworkInformation.NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    System.Net.NetworkInformation.IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        public ActionResult Index()

        {
            return View();
        }
        public ActionResult actualizarContrasena(string id)
        {
            Session["customerId"] = id;
            return View();
        }
        public ActionResult updatePassword(Models.updatePassword model)
        {
            ConnectionDataBase.StoreProcediur data = new ConnectionDataBase.StoreProcediur();
            CredencialesDeAcceso acceso = new CredencialesDeAcceso();
            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.GenerateKey();
            myRijndael.GenerateIV();
            if (Request["newpassword"] == Request["confirmnewpassword"])
            {
                string sub = Session["customerId"].ToString();
                Byte[] contrasenaEncriptada = acceso.EncryptStringToBytes(Request["newpassword"], myRijndael.Key, myRijndael.IV);
                DataTable dtd = data.validacionContrasenaActual(sub);
                DataRow rowd = dtd.Rows[0];
                byte[] contrasena = (byte[])rowd["contrasena"];
                byte[] key = (byte[])rowd["pKEY"];
                byte[] iv = (byte[])rowd["PIV"];
                string contrasenaFinal = acceso.DecryptStringFromBytes(contrasena, key, iv);
                if (contrasenaFinal != Request["newpassword"].ToString())
                {
                    Byte[] contrasenaEncriptadaAntigua = acceso.EncryptStringToBytes(model.actual, myRijndael.Key, myRijndael.IV);
                    DataTable dt = data.actualizarContrasenaConfirmacion(sub, contrasenaEncriptada, myRijndael.Key, myRijndael.IV, contrasenaEncriptadaAntigua, myRijndael.Key, myRijndael.IV);
                    DataRow row = dt.Rows[0];
                    if (dt.Rows.Count == 1)
                    {
                        Session["message"] = "Contraseña actualizada con éxito.";
                        Session["title"] = "Muy bien";
                        Session["type"] = "success";
                        return RedirectToAction("Login", "Home");
                    }
                }
                else
                {
                    Session["message"] = "Por favor ingrese otra contraseña, la que ingreso ya fue usada en el sistema";
                    Session["title"] = "Notificación";
                    Session["type"] = "warning";
                    return RedirectToAction("Login", "Home");
                }
            }
            Session["message"] = "Las contraseñas no coinciden, verifique.";
            Session["type"] = "error";
            return RedirectToAction("actualizarContrasena", "Home", new { id = Session["customerId"].ToString()});
        }
    }
}