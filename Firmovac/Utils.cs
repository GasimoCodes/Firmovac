using CsvHelper;
using Firmovac.DataDefinitions;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Mail;
using CsvHelper.Configuration;
using Newtonsoft.Json;

namespace Firmovac
{
    public class Utils
    {
        public static SiteConfig siteConfig = new SiteConfig();



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
            string result;
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<FirmaCsvMap>();
                csv.WriteRecords(firms);
                result = writer.ToString();
            }
            return result;
        }

        public static void SaveConfig()
        {
            string jsonString = JsonConvert.SerializeObject(siteConfig);

            // write the string to a file
            using (StreamWriter writer = new StreamWriter("FirmovacConfig.json"))
            {
                writer.Write(jsonString);
            }
        }

        public static void LoadConfig()
        {
            // File doesnt exist
            if (!File.Exists("FirmovacConfig.json"))
            {
                SaveConfig();
            }

            using (StreamReader reader = new StreamReader("FirmovacConfig.json"))
            {
                string json = reader.ReadToEnd();
                try
                {
                    siteConfig = JsonConvert.DeserializeObject<SiteConfig>(json);
                }
                catch(Exception ex)
                {
                    SaveConfig();
                    throw (ex);
                }

            }
        }



    }
}
