using AlmassarGate.Domain.Models.Common;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace AlmassarGate.Domain.Utilities
{
    public class SendEmail
    {
        public async static void SendEmails(string Email, string Subject, string Body)
        {
            try
            {
                AppConfiguration appConfiguration = new AppConfiguration();
                //SmtpClient client = new SmtpClient("mail.businicity.com") 
                //{
                //    UseDefaultCredentials = false,
                //    Port = 465,
                //    Credentials = new NetworkCredential(appConfiguration.Email, appConfiguration.EmailPassword),
                //    EnableSsl = false,

                //};
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(appConfiguration.Email);
                email.To.Add(MailboxAddress.Parse(Email));
                email.Subject = Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = Body;
                email.Body = builder.ToMessageBody();
                 var smtp = new SmtpClient();
                smtp.Connect("mail.businicity.com", 25, SecureSocketOptions.StartTls);
                smtp.Authenticate(appConfiguration.Email, appConfiguration.EmailPassword);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                //MailAddress mailFrom = new MailAddress(appConfiguration.Email);
                //MailMessage mail = new MailMessage();
                //mail.IsBodyHtml = true;
                //mail.From = mailFrom;
                //mail.To.Add(Email);
                //mail.Subject = Subject;
                //mail.Body = Body;
                //client.Send(mail);
                //mail.Dispose();

            }
            catch (Exception e)
            {
                var z = e;
            }
        }
    }
}
