using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTTT.Ejemplo.Persona
{
    public partial class ErrorPage : System.Web.UI.Page
    {
  


    protected void Page_Load(object sender, EventArgs e)
        {
            EmailMal(PersonaPrincipal.error);

        }

        public void EmailMal(string error)
        {
        MailMessage mail = new MailMessage();
        SmtpClient smtpmail = new SmtpClient();
        mail.From = new MailAddress("ShendelLA1234@gmail.com");
            mail.To.Add(new MailAddress("19301096@uttt.edu.mx"));
            mail.Subject = "¡Hola!";

            mail.Body = "Soy un email de error, ¡No te preocupes! :D" + error;

            smtpmail.Port = 587;
            smtpmail.Host = "smtp.gmail.com";
            smtpmail.EnableSsl = true;
            smtpmail.UseDefaultCredentials = false;
            smtpmail.Credentials = new NetworkCredential("ShendelLA1234@gmail.com", "SLA2429S");
            smtpmail.DeliveryMethod = SmtpDeliveryMethod.Network;


            
            smtpmail.Send(mail);
        }
    }
}