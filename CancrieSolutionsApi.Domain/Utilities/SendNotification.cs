using AlmassarGate.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.Utilities
{
    public class SendNotification
    {
        public async static void SendEmails(string Email, string Subject, string Body)
        {
            try
            {
                AppConfiguration appConfiguration = new AppConfiguration();


                MailMessage mail = new MailMessage();
                mail.To.Add(Email);
                mail.From = new MailAddress(appConfiguration.Email);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.businicity.com", 587);
                
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(appConfiguration.Email, appConfiguration.EmailPassword);
                smtp.EnableSsl = true;
                
                smtp.Send(mail);


            }
            catch (Exception e)
            {
                var z = e;
            }
        }
    }
}
