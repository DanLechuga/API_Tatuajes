using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Repositorios
{
    public class RepositorioNotificaciones : IRepositorioNotificaciones
    {
        
        public RepositorioNotificaciones()
        {

        }
        public void EnviarCorreoNotificacion(Usuario usuario)
        {            
            string from = "danlechuga@live.com";
            string displayname = "Developer@Support";
            string body = $"<style>"+
                            "h1{color:black;}"+
                            "h2{color:black;}" +
                            "</style>"+
                            "<h1>Su contraseña es: <br />" + usuario.UsuarioPassword.ContraseniaValida+"</h1><br />"+
                            "<h2>Si no empezo el proceso de recuperacion de password envie un email este correo.<br /> Gracias</h2>";
            try
            {
                MailMessage mail = new();
                mail.From = new MailAddress(from,displayname);
                mail.To.Add(usuario.UsuarioCorreo.Cadenavalida);
                mail.Subject = "Correo de recuperacion de password";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient client = new("smtp.office365.com", 587);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(from, "Nolose6267mams");
                client.EnableSsl = true;
                client.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
