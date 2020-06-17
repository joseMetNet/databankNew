using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DATABANK.Models
{

    public class Login
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }

    public class updatePassword
    {
        public string actual { get; set; }
        public string newpassword { get; set; }
        public string confirmnewpassword { get; set; }
    }
    public class forgotYourPassword
    {
        public string email { get; set; }
    }

    public class usuarios
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string idPerfil { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public byte[] passwordEncriptado { get; set; }
        public int idEstado { get; set; }
        public string imagen { get; set; }
        public string codigo { get; set; }

    }
    public class Bodega
    {
        public int idBodega { get; set; }
        public string Nombre { get; set; }
        public string imagen { get; set; }
        public string codigo { get; set; }
        public int idEstado { get; set; }
        public int idProyecto { get; set; }
        public int idDepartamento { get; set; }
        public int idMunicipio { get; set; }
    }
    public class Proyecto
    {
        public int idProyecto { get; set; }
        public int idSucursal { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Logo { get; set; }
        public int idEstado { get; set; }
        public int idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string DocumentoUsuario { get; set; }
        public string Usuario { get; set; }
        public string EmailUsuario { get; set; }
        public string TelefonoUsuario { get; set; }
        public string Todo { get; set; }
        public string Guardar { get; set; }
        public string Editar { get; set; }
        public string Eliminar { get; set; }
        public string Importar { get; set; }
        public string Exportar { get; set; }
        public int idDepartamento { get; set; }
        public int idMunicipio { get; set; }

    }
    public class Producto
    {
        public int idProducto { get; set; }
        public int idBodega { get; set; }
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public int idUnidadMedida { get; set; }
        public string Ubicacion { get; set; }
        public int idEstado { get; set; }
        public string descripcion { get; set; }
        public int idUsuario { get; set; }

    }
    public class Inspeccion
    {
        public int idInspecion { get; set; }
        public int idProyecto { get; set; }
        public int idBodega { get; set; }
        public int idProducto { get; set; }
        public string Observacion { get; set; }
        public string ubicacionAuxiliar { get; set; }
        public int idEstado { get; set; }
        public int idCategoria { get; set; }
        public string Conteo { get; set; }
        public string profileImg { get; set; }
        public int idBodegaP { get; set; }
        public string codigoP { get; set; }
        public string descripcionP { get; set; }
        public int cantidadP { get; set; }
        public int idUnidadMedidaP { get; set; }
        public string UbicacionP { get; set; }
    }

}