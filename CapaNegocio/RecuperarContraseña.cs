using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace CapaNegocio
{
    public class RecuperarContraseña
    {
        public int Enviar(string emisor, string password, string receptor, out string errorMessage)
        {
            Random r = new Random();
            int numero = r.Next(100000, 1000000);
            MailMessage msg = new MailMessage();
            msg.To.Add(receptor);
            msg.Subject = "Correo de verificacion";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Su codigo de verificacion para recuperar la contraseña es: '"+numero+"' Por favor ingréselo en el sistema.";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(emisor);
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(emisor, password);
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";

            try
            {
                client.Send(msg);
                errorMessage = null;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                numero = 0;
            }
            return numero;

        }
    }
}
