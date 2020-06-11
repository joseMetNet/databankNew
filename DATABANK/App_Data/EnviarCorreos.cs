using System;
using System.Globalization;
using System.Net.Mail;
using System.Data;
using System.Linq;

using System.Web.Mvc;

namespace DATABANK.App_Data
{
    public class EnviarCorreos : Controller
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJLMNOPQRSTUVWXYZabcdefghijlmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // GET: EnviarCorreos

        public void EnviarCorreo(string correoAlQueEnvio, string asuntoDelCorreo, string copiaCorreoEnvio, string textoDelCorreo, string correoDesdeElQueEnvio, string usuarioCorreEnvio, string contrasenaCorreoEnvio, string archivo)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(correoAlQueEnvio);
            //Asunto
            mmsg.Subject = asuntoDelCorreo;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF32;
            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add(copiaCorreoEnvio);
            //Cuerpo del Mensaje
            mmsg.Body = textoDelCorreo;


            mmsg.BodyEncoding = System.Text.Encoding.UTF32;
            mmsg.IsBodyHtml = false;
            if (archivo.Length > 2) mmsg.Attachments.Add(new Attachment(archivo));
            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(correoDesdeElQueEnvio);

            /*-------------------------CLIENTE DE CORREO----------------------*/
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential(usuarioCorreEnvio, contrasenaCorreoEnvio);
            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.office365.com";
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.Timeout = 5000;
            mmsg.IsBodyHtml = true;
            try
            {
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException)
            {
            }
        }

        public string ArmarCorreoRecuperacionContrasenaMobil(string nombreUsuario, string contrasena, int genero, string celular)
        {
            string strBody = "<html>";
            strBody += "<head><style type=\"text/css\">.curpointer {cursor: pointer;}</style></head> ";
            strBody += "<body style='font-family: Leitura Sans Grot 1; font-size: 14px; color: #323E48'>";
            strBody += "<p>Estimado(a) "+ nombreUsuario+",</p>";
            strBody += "<label>Si solicit&oacute; un restablecimiento de contrase&ntilde;a, haga clic en el bot&oacute;n a continuaci&oacute;n.</label></br>";
            strBody += "<label>Su contrase&ntilde;a temporal es: " + contrasena + "</label></br>";
            strBody += "<p><a href='http://databankmetnet.azurewebsites.net/Home/actualizarContrasena?id={1}'><img src=\"http://databankmetnet.azurewebsites.net/Content/dist/img/button_restablecer-la-contrasena.png\" width= \"235\" height=\"35\" alt=\"logo\"></a></p>";
            strBody += "<p>Si no realiz&oacute; esta solicitud, ignore este correo electr&oacute;nico.</p>";
            strBody += "<p>Atentamente,&nbsp;</p>";
            strBody += "<p><img src=\"http://databankmetnet.azurewebsites.net/Content/images/abacus.png\" width= \"240\" height=\"100\" alt=\"logo\">";
            strBody += "<br><br>";
            strBody += "</body>";
            strBody += "</html>";
            strBody = strBody.Replace("{1}", celular);
            return strBody;
        }

        public string ArmarCorreoUsuarioNuevo(string nombre, string apellido, string nombreUsuario, string contrasena, string celular)
        {
            string strBody = "<html>";
            strBody += "<head><style type=\"text/css\">.curpointer {cursor: pointer;}</style></head> ";
            strBody += "<body style='font-family: Leitura Sans Grot 1; font-size: 14px; color: #323E48'>";
            strBody += "<p>Estimado(a) " + nombre + " "+ apellido + ",</p>";
            strBody += "<label>Su nombre de usuario y contrase&ntilde;a para Databank se han creado de la siguiente manera:&nbsp;</label></br>";
            strBody += "<label>Usuario: " + nombreUsuario + "</label></br>";
            strBody += "<label>Contrase&ntilde;a: " + contrasena + "</label></br>";
            strBody += "<p><a href='http://databankmetnet.azurewebsites.net'><img src=\"http://databankmetnet.azurewebsites.net/Content/dist/img/button_ir-al-sitio-web.png\" width= \"150\" height=\"35\" alt=\"logo\"></a></p>";
            strBody += "<p>Si no realiz&oacute; esta solicitud, ignore este correo electr&oacute;nico.</p>";
            strBody += "<p>Atentamente,&nbsp;</p>";
            strBody += "<p><img src=\"http://databankmetnet.azurewebsites.net/Content/images/abacus.png\" width= \"240\" height=\"100\" alt=\"logo\">";
            strBody += "<br><br>";
            strBody += "</body>";
            strBody += "</html>";
            strBody += "</body>";
            strBody += "</html>";
            return strBody;
        }

    }
}
