using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class StaticFunctions
    {

        public static bool SendMail(string toEmail, string body, string subject)
        {
            string CC = string.Empty;
            string MailFrom = string.Empty;
            string DisplayedName = string.Empty;
            string Host = string.Empty;
            string UserName = string.Empty;
            string Password = string.Empty;


            MailFrom = "noreply@cib-pay.com";
            DisplayedName = "Translations";
            Host = "smtp.emailsrvr.com";
            UserName = "noreply@cib-pay.com";
            Password = "cm45bike";



            bool IsEmailSent = false;
            MailMessage mail = new MailMessage();

            //mail.CC.Add(CC);

            mail.IsBodyHtml = true;
            mail.Body = body;

            mail.From = new MailAddress(MailFrom, DisplayedName);
            mail.Subject = subject;

            mail.To.Add(toEmail);

            mail.Priority = System.Net.Mail.MailPriority.High;

            SmtpClient client = new SmtpClient();
            client.Host = Host;
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(UserName, Password);
            client.Timeout = 20000;

            try
            {
                
                client.Send(mail);
                IsEmailSent = true;
            }
            catch (SmtpException)
            {
               
            }
            finally
            {
                mail.Dispose();
                client.Dispose();
            }

            return IsEmailSent;
        }
    }
}
