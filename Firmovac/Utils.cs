using Firmovac.DataDefinitions;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Firmovac
{
    public class Utils
    {


        public static async Task OnPostSendEmail(string from, string to, string subject, string body)
        {
            using (var smtp = new SmtpClient("Your SMTP server address"))
            {
                var emailMessage = new MailMessage();
                emailMessage.From = new MailAddress(from);
                emailMessage.To.Add(to);
                emailMessage.Subject = subject;
                emailMessage.Body = body;
                await smtp.SendMailAsync(emailMessage);
            }
        }

        public static string generateCSVReport(Firma[] firms)
        {

            return "";
        }


    }
}
