using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DATABANK.App_Data
{
    public class ConnectionDataBase
    {
        public class StoreProcediur
        {
            public DataTable ObtenerData(string SP)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter(SP, con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message;
                    throw;
                }
            }

            public DataTable ValidarIngresoUsuario(string usuario, string macAddress)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_ValidacionIngreso", con);
                    da.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
                    da.SelectCommand.Parameters.Add("@macAddress", SqlDbType.VarChar).Value = macAddress;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable verifySession(int pidUser = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_VerifySession", con);
                    da.SelectCommand.Parameters.Add("@pidUser", SqlDbType.Int).Value = pidUser;
                    da.SelectCommand.Parameters.Add("@pidDate", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable actualizarContrasena(string email, byte[] contrasena, byte[] key, byte[] iv)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SPActualizarContrasena", con);
                    da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    da.SelectCommand.Parameters.Add("@password", SqlDbType.VarBinary).Value = contrasena;
                    da.SelectCommand.Parameters.Add("@Key", SqlDbType.VarBinary).Value = key;
                    da.SelectCommand.Parameters.Add("@IV", SqlDbType.VarBinary).Value = iv;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable removeSession(int pidUser = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_RemoveSession", con);
                    da.SelectCommand.Parameters.Add("@pidUser", SqlDbType.Int).Value = pidUser;
                    da.SelectCommand.Parameters.Add("@pidDate", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataUsuario(int pidUsuario = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getDataUsuario", con);
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.Int).Value = pidUsuario;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveUsuario(DATABANK.Models.usuarios model, byte[] contrasena, Byte[] pKEY, Byte[] pIV)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveUsuario", con);
                    da.SelectCommand.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = model.nombre;
                    da.SelectCommand.Parameters.Add("@papellido", SqlDbType.VarChar).Value = model.apellido;
                    da.SelectCommand.Parameters.Add("@pdocumento", SqlDbType.VarChar).Value = model.documento;
                    da.SelectCommand.Parameters.Add("@ptelefono", SqlDbType.VarChar).Value = model.telefono;
                    da.SelectCommand.Parameters.Add("@pdireccion", SqlDbType.VarChar).Value = model.direccion;
                    da.SelectCommand.Parameters.Add("@pemail", SqlDbType.VarChar).Value = model.email;
                    da.SelectCommand.Parameters.Add("@pimagen", SqlDbType.VarChar).Value = model.imagen;
                    da.SelectCommand.Parameters.Add("@pidPerfil", SqlDbType.Int).Value = model.idPerfil;
                    da.SelectCommand.Parameters.Add("@pusuario", SqlDbType.VarChar).Value = model.usuario;
                    da.SelectCommand.Parameters.Add("@pcontrasena", SqlDbType.VarBinary).Value = contrasena;
                    da.SelectCommand.Parameters.Add("@pkey", SqlDbType.VarBinary).Value = pKEY;
                    da.SelectCommand.Parameters.Add("@piv", SqlDbType.VarBinary).Value = pIV;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = 1;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveUsuarioProyecto(DATABANK.Models.Proyecto model, byte[] contrasena, Byte[] pKEY, Byte[] pIV)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveUsuario", con);
                    da.SelectCommand.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = model.NombreUsuario;
                    da.SelectCommand.Parameters.Add("@papellido", SqlDbType.VarChar).Value = model.ApellidoUsuario;
                    da.SelectCommand.Parameters.Add("@pdocumento", SqlDbType.VarChar).Value = model.DocumentoUsuario;
                    da.SelectCommand.Parameters.Add("@ptelefono", SqlDbType.VarChar).Value = model.TelefonoUsuario;
                    da.SelectCommand.Parameters.Add("@pdireccion", SqlDbType.VarChar).Value = "";
                    da.SelectCommand.Parameters.Add("@pemail", SqlDbType.VarChar).Value = model.EmailUsuario;
                    da.SelectCommand.Parameters.Add("@pimagen", SqlDbType.VarChar).Value = "";
                    da.SelectCommand.Parameters.Add("@pidPerfil", SqlDbType.Int).Value = 1;
                    da.SelectCommand.Parameters.Add("@pusuario", SqlDbType.VarChar).Value = model.Usuario;
                    da.SelectCommand.Parameters.Add("@pcontrasena", SqlDbType.VarBinary).Value = contrasena;
                    da.SelectCommand.Parameters.Add("@pkey", SqlDbType.VarBinary).Value = pKEY;
                    da.SelectCommand.Parameters.Add("@piv", SqlDbType.VarBinary).Value = pIV;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = 1;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveUsuarioUpdate(DATABANK.Models.usuarios model, Byte[] pKEY, Byte[] pIV)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveUsuarioUpdate", con);
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.VarChar).Value = model.idUsuario;
                    da.SelectCommand.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = model.nombre;
                    da.SelectCommand.Parameters.Add("@papellido", SqlDbType.VarChar).Value = model.apellido;
                    da.SelectCommand.Parameters.Add("@pdocumento", SqlDbType.VarChar).Value = model.documento;
                    da.SelectCommand.Parameters.Add("@ptelefono", SqlDbType.VarChar).Value = model.telefono;
                    da.SelectCommand.Parameters.Add("@pdireccion", SqlDbType.VarChar).Value = model.direccion;
                    da.SelectCommand.Parameters.Add("@pemail", SqlDbType.VarChar).Value = model.email;
                    da.SelectCommand.Parameters.Add("@pimagen", SqlDbType.VarChar).Value = model.imagen;
                    da.SelectCommand.Parameters.Add("@pidPerfil", SqlDbType.Int).Value = model.idPerfil;
                    da.SelectCommand.Parameters.Add("@pusuario", SqlDbType.VarChar).Value = model.usuario;
                    da.SelectCommand.Parameters.Add("@pcontrasena", SqlDbType.VarBinary).Value = model.passwordEncriptado;
                    da.SelectCommand.Parameters.Add("@pkey", SqlDbType.VarBinary).Value = pKEY;
                    da.SelectCommand.Parameters.Add("@piv", SqlDbType.VarBinary).Value = pIV;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = 1;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable validacionContrasenaActual(string numeroCelular)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SPValidacionContrasenaAntigua", con);
                    da.SelectCommand.Parameters.Add("@numeroTelefonico", SqlDbType.VarChar).Value = numeroCelular;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable actualizarContrasenaConfirmacion(string numeroCelular, byte[] contrasena, byte[] key, byte[] iv, byte[] contrasenaAntigua, byte[] keyAntigua, byte[] ivAntigua)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SPActualizarContrasenaConfirmacion", con);
                    da.SelectCommand.Parameters.Add("@numeroCelular", SqlDbType.VarChar).Value = numeroCelular;
                    da.SelectCommand.Parameters.Add("@contrasena", SqlDbType.VarBinary).Value = contrasena;
                    da.SelectCommand.Parameters.Add("@Key", SqlDbType.VarBinary).Value = key;
                    da.SelectCommand.Parameters.Add("@IV", SqlDbType.VarBinary).Value = iv;
                    da.SelectCommand.Parameters.Add("@contrasenaAntigua", SqlDbType.VarBinary).Value = contrasenaAntigua;
                    da.SelectCommand.Parameters.Add("@KeyAntigua", SqlDbType.VarBinary).Value = keyAntigua;
                    da.SelectCommand.Parameters.Add("@IVAntigua", SqlDbType.VarBinary).Value = ivAntigua;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataBodega(int pidBodega = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getDataBodega", con);
                    da.SelectCommand.Parameters.Add("@pidBodega", SqlDbType.Int).Value = pidBodega;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getProyectoBodega(int pidProyecto = 0, int pidUsuario = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getProyectoBodega", con);
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.Int).Value = pidUsuario;
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getListaInspección(int pidProyecto = 0, int pidUsuario = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getListaInspección", con);
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.Int).Value = pidUsuario;
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getConteoInspeccion(int pidProyecto = 0, int pidUsuario = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getConteoInspeccion", con);
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.Int).Value = pidUsuario;
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataProducto(int pidProducto = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getProducto", con);
                    da.SelectCommand.Parameters.Add("@pidProducto", SqlDbType.Int).Value = pidProducto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataInventario(int pidInventario = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getDataInventario", con);
                    da.SelectCommand.Parameters.Add("@pidInventario", SqlDbType.Int).Value = pidInventario;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataAlmacenBodega(int pidAlmacen = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getAlmacenBodega", con);
                    da.SelectCommand.Parameters.Add("@pidAlmacen", SqlDbType.Int).Value = pidAlmacen;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataAlmacen(int pidAlmacen = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getDataAlmacen", con);
                    da.SelectCommand.Parameters.Add("@pidAlmacen", SqlDbType.Int).Value = pidAlmacen;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveBodega(DATABANK.Models.Bodega model)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveBodega", con);
                    da.SelectCommand.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = model.Nombre;
                    da.SelectCommand.Parameters.Add("@pimagen", SqlDbType.VarChar).Value = model.imagen;
                    da.SelectCommand.Parameters.Add("@pcodigo", SqlDbType.VarChar).Value = model.codigo;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = 1;
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = model.idProyecto;
                    da.SelectCommand.Parameters.Add("@pidDepartamento", SqlDbType.Int).Value = model.idDepartamento;
                    da.SelectCommand.Parameters.Add("@pidMunicipio", SqlDbType.Int).Value = model.idMunicipio;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveProducto(DATABANK.Models.Producto model)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveProducto", con);
                    da.SelectCommand.Parameters.Add("@pidBodega", SqlDbType.Int).Value = model.idBodega;
                    da.SelectCommand.Parameters.Add("@pCodigo", SqlDbType.VarChar).Value = model.Codigo;
                    da.SelectCommand.Parameters.Add("@pNombreProducto", SqlDbType.VarChar).Value = model.NombreProducto;
                    da.SelectCommand.Parameters.Add("@pcantidad", SqlDbType.Int).Value = model.Cantidad;
                    da.SelectCommand.Parameters.Add("@pidUnidadMedida", SqlDbType.Int).Value = model.idUnidadMedida;
                    da.SelectCommand.Parameters.Add("@pUbicacion", SqlDbType.VarChar).Value = model.Ubicacion;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = 1;
                    da.SelectCommand.Parameters.Add("@pdescripcion", SqlDbType.VarChar).Value = model.descripcion;
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.Int).Value = model.idUsuario;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }

            public DataTable saveUsuarioMaterial(int pidProyecto, int pidProducto, int pidUsuario)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveUsuarioMaterial", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.Parameters.Add("@pidProducto", SqlDbType.Int).Value = pidProducto;
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.VarChar).Value = pidUsuario;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveUsuarioMaterialUpdate(int pidProducto, int idUsuario)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveUsuarioMaterialUpdate", con);
                    da.SelectCommand.Parameters.Add("@pidProducto", SqlDbType.Int).Value = pidProducto;
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.VarChar).Value = idUsuario;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable ActualizarEstadoTemporal(int pidProducto, int idUsuario, int idEstado, int conteo)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_ActualizarEstadoTemporal", con);
                    da.SelectCommand.Parameters.Add("@pidProducto", SqlDbType.Int).Value = pidProducto;
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.VarChar).Value = idUsuario;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.VarChar).Value = idEstado;
                    da.SelectCommand.Parameters.Add("@pconteo", SqlDbType.VarChar).Value = conteo;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable ActualizarEstadoProducto(int pidProyecto)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_ActualizarTemporal", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveProductoUpdate(DATABANK.Models.Producto model)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveProductoUpdate", con);
                    da.SelectCommand.Parameters.Add("@pidProducto", SqlDbType.Int).Value = model.idProducto;
                    da.SelectCommand.Parameters.Add("@pidBodega", SqlDbType.Int).Value = model.idBodega;
                    da.SelectCommand.Parameters.Add("@pCodigo", SqlDbType.VarChar).Value = model.Codigo;
                    da.SelectCommand.Parameters.Add("@pNombreProducto", SqlDbType.VarChar).Value = model.NombreProducto;
                    da.SelectCommand.Parameters.Add("@pcantidad", SqlDbType.Int).Value = model.Cantidad;
                    da.SelectCommand.Parameters.Add("@pidUnidadMedida", SqlDbType.Int).Value = model.idUnidadMedida;
                    da.SelectCommand.Parameters.Add("@pUbicacion", SqlDbType.VarChar).Value = model.Ubicacion;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = model.idEstado;
                    da.SelectCommand.Parameters.Add("@pdescripcion", SqlDbType.VarChar).Value = model.descripcion;
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.Int).Value = model.idUsuario;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveBodegaUpdate(DATABANK.Models.Bodega model)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveBodegaUpdate", con);
                    da.SelectCommand.Parameters.Add("@pidBodega", SqlDbType.Int).Value = model.idBodega;
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = model.idProyecto;
                    da.SelectCommand.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = model.Nombre;
                    da.SelectCommand.Parameters.Add("@pimagen", SqlDbType.VarChar).Value = model.imagen;
                    da.SelectCommand.Parameters.Add("@pcodigo", SqlDbType.VarChar).Value = model.codigo;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = model.idEstado;
                    da.SelectCommand.Parameters.Add("@pidDepartamento", SqlDbType.Int).Value = model.idDepartamento;
                    da.SelectCommand.Parameters.Add("@pidMunicipio", SqlDbType.Int).Value = model.idMunicipio;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable deActivateUser(int pidUsuario = 0, int pidEstado = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_deActivateUser", con);
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.Int).Value = pidUsuario;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = pidEstado;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable deActivateAlmacen(int pidAlmacen = 0, int pidEstado = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_deActivateAlmacen", con);
                    da.SelectCommand.Parameters.Add("@pidAlmacen", SqlDbType.Int).Value = pidAlmacen;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = pidEstado;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable deActivateBodega(int pidBodega = 0, int pidEstado = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_deActivateBodega", con);
                    da.SelectCommand.Parameters.Add("@pidBodega", SqlDbType.Int).Value = pidBodega;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = pidEstado;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }

            public DataTable deActivateProyecto(int pidProyecto = 0, int pidEstado = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_deActivateProyecto", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = pidEstado;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable deActivateUserProyecto(int pidProyectoUsuario = 0, int pidEstado = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_deActivateUserProyecto", con);
                    da.SelectCommand.Parameters.Add("@pidProyectoUsuario", SqlDbType.Int).Value = pidProyectoUsuario;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = pidEstado;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable deActivateInventario(int pidInventario = 0, int pidEstado = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_deActivateInventario", con);
                    da.SelectCommand.Parameters.Add("@pidInventario", SqlDbType.Int).Value = pidInventario;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = pidEstado;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataProyecto(int pidProyecto = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getDataProyecto", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataDepartamento(int pidDepartamento = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getDataDepartamento", con);
                    da.SelectCommand.Parameters.Add("@pidDepartamento", SqlDbType.Int).Value = pidDepartamento;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDataProyectoUsuario(int pidProyecto = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getDataProyectoUsuario", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getDepartamentoMunicipio(int pidDepartamento)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getDepartamentoMunicipio", con);
                    da.SelectCommand.Parameters.Add("@pidDepartamento", SqlDbType.Int).Value = pidDepartamento;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveProyecto(DATABANK.Models.Proyecto model)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveProyecto", con);
                    da.SelectCommand.Parameters.Add("@pidSucursal", SqlDbType.Int).Value = model.idSucursal;
                    da.SelectCommand.Parameters.Add("@pdocumento", SqlDbType.VarChar).Value = model.Documento;
                    da.SelectCommand.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = model.Nombre;
                    da.SelectCommand.Parameters.Add("@pdescripcion", SqlDbType.VarChar).Value = model.Descripcion;
                    da.SelectCommand.Parameters.Add("@pCliente", SqlDbType.VarChar).Value = model.Cliente;
                    da.SelectCommand.Parameters.Add("@pdireccion", SqlDbType.VarChar).Value = model.Direccion;
                    da.SelectCommand.Parameters.Add("@ptelefono", SqlDbType.VarChar).Value = model.Telefono;
                    da.SelectCommand.Parameters.Add("@plogo", SqlDbType.VarChar).Value = model.Logo;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = 1;
                    da.SelectCommand.Parameters.Add("@pidDepartamento", SqlDbType.Int).Value = model.idDepartamento;
                    da.SelectCommand.Parameters.Add("@pidMunicipio", SqlDbType.Int).Value = model.idMunicipio;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }

            public DataTable savePermiso(int id, string t, string g, string ed, string d, string im, string ex)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_savePermiso", con);
                    da.SelectCommand.Parameters.Add("@pidProyectoUsuario", SqlDbType.Int).Value = id;
                    da.SelectCommand.Parameters.Add("@ptodo", SqlDbType.VarChar).Value = t;
                    da.SelectCommand.Parameters.Add("@pguardar", SqlDbType.VarChar).Value = g;
                    da.SelectCommand.Parameters.Add("@peditar", SqlDbType.VarChar).Value = ed;
                    da.SelectCommand.Parameters.Add("@peliminar", SqlDbType.VarChar).Value = d;
                    da.SelectCommand.Parameters.Add("@pimportar", SqlDbType.VarChar).Value = im;
                    da.SelectCommand.Parameters.Add("@pexportar", SqlDbType.VarChar).Value = ex;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }

            public DataTable saveProyectoUpdate(DATABANK.Models.Proyecto model)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveProyectoUpdate", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = model.idProyecto;
                    da.SelectCommand.Parameters.Add("@pidSucursal", SqlDbType.Int).Value = model.idSucursal;
                    da.SelectCommand.Parameters.Add("@pdocumento", SqlDbType.VarChar).Value = model.Documento;
                    da.SelectCommand.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = model.Nombre;
                    da.SelectCommand.Parameters.Add("@pdescripcion", SqlDbType.VarChar).Value = model.Descripcion;
                    da.SelectCommand.Parameters.Add("@pCliente", SqlDbType.VarChar).Value = model.Cliente;
                    da.SelectCommand.Parameters.Add("@pdireccion", SqlDbType.VarChar).Value = model.Direccion;
                    da.SelectCommand.Parameters.Add("@ptelefono", SqlDbType.VarChar).Value = model.Telefono;
                    da.SelectCommand.Parameters.Add("@plogo", SqlDbType.VarChar).Value = model.Logo;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = model.idEstado;
                    da.SelectCommand.Parameters.Add("@pidDepartamento", SqlDbType.Int).Value = model.idDepartamento;
                    da.SelectCommand.Parameters.Add("@pidMunicipio", SqlDbType.Int).Value = model.idMunicipio;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable saveProyectoUsuario(DATABANK.Models.Proyecto model, int idUsuario)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveProyectoUsuario", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = model.idProyecto;
                    da.SelectCommand.Parameters.Add("@pidUsuario", SqlDbType.Int).Value = idUsuario;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = 1;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable ObtenerUnidadMedida(string pUnidadMedida)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_ObtenerUnidadMedida", con);
                    da.SelectCommand.Parameters.Add("@pUnidadMedida", SqlDbType.VarChar).Value = pUnidadMedida;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable ObtenerBodega(string pBodega)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_ObtenerBodega", con);
                    da.SelectCommand.Parameters.Add("@pBodega", SqlDbType.VarChar).Value = pBodega;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable ObtenerOperario(string pOperario)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_ObtenerOperario", con);
                    da.SelectCommand.Parameters.Add("@pOperario", SqlDbType.VarChar).Value = pOperario;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable CargarMaterialesTemporal(DataTable Materiales)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_cargarMateriales", con);
                    da.SelectCommand.Parameters.Add("@TablaCargar", SqlDbType.Structured).Value = Materiales;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public DataTable CargarErrores(DataTable Materiales)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_cargarErrores", con);
                    da.SelectCommand.Parameters.Add("@TablaCargar", SqlDbType.Structured).Value = Materiales;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public DataTable eliminarTemporalErrores(int pidProyecto)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_EliminarTemporalErrores", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public DataTable CargarTablaMateriales(int pidProyecto)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_cargarTablaMateriales", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public DataTable getMaterialesBodega(int pidProyecto)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getMaterialesBodega", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public DataTable getErrores(int pidProyecto)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getErrores", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public DataTable getEstado(int ptipo)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getestado", con);
                    da.SelectCommand.Parameters.Add("@ptipo", SqlDbType.Int).Value = ptipo;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public DataTable saveInspeccion(DATABANK.Models.Inspeccion model, int pidProyecto)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveInspeccion", con);
                    da.SelectCommand.Parameters.Add("@pidProyecto", SqlDbType.Int).Value = pidProyecto;
                    da.SelectCommand.Parameters.Add("@pidBodega", SqlDbType.Int).Value = model.idBodega;
                    da.SelectCommand.Parameters.Add("@pidProducto", SqlDbType.Int).Value = model.idProducto;
                    da.SelectCommand.Parameters.Add("@pobservacion", SqlDbType.VarChar).Value = model.Observacion;
                    da.SelectCommand.Parameters.Add("@pUbicacionAuxiliar", SqlDbType.VarChar).Value = model.ubicacionAuxiliar;
                    da.SelectCommand.Parameters.Add("@pidEstado", SqlDbType.Int).Value = model.idEstado;
                    if (model.idCategoria == 0)
                    {
                        da.SelectCommand.Parameters.Add("@pidCategoria", SqlDbType.Int).Value = 5;
                    }
                    else
                    {
                        da.SelectCommand.Parameters.Add("@pidCategoria", SqlDbType.Int).Value = model.idCategoria;
                    }
                    da.SelectCommand.Parameters.Add("@pconteo", SqlDbType.Int).Value = model.Conteo;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getImageplus(int id)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getImagePlus", con);
                    da.SelectCommand.Parameters.Add("@pidInspeccion", SqlDbType.Int).Value = id;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {
                    throw;

                }
            }
            public DataTable saveImg(string nameImg, string srcImg, int idProducto, int idInspeccion)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_saveImgInspeccion", con);
                    da.SelectCommand.Parameters.Add("@pidInspeccion", SqlDbType.Int).Value = idInspeccion;
                    da.SelectCommand.Parameters.Add("@pidProducto", SqlDbType.Int).Value = idProducto;
                    da.SelectCommand.Parameters.Add("@pnameImg", SqlDbType.VarChar).Value = nameImg;
                    da.SelectCommand.Parameters.Add("@psrcImg", SqlDbType.VarChar).Value = srcImg;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            public DataTable getInspeccion(int pidInspeccion = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("SP_getInspecciones", con);
                    da.SelectCommand.Parameters.Add("@pidInspeccion", SqlDbType.Int).Value = pidInspeccion;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }
            public DataTable getUsuarioProyecto(int pidBodega = 0)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("[SP_getUsuarioProyecto]", con);
                    da.SelectCommand.Parameters.Add("@pidBodega", SqlDbType.Int).Value = pidBodega;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {

                    string sas = e.Message; throw;
                }
            }

        }
    }
}
