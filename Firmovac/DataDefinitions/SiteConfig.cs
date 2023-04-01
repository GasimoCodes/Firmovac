using Newtonsoft.Json;

namespace Firmovac.DataDefinitions
{
    [Serializable]
    public class SiteConfig
    {
        // Mailer Config
        public string Admin_Email { get; set; }
        public string SMTP_Address {get;set;}
        public string SMTP_Password { get;set;}

        // DB Config
        public string DB_IP = "37.120.169.246";
        public string DB_Password = "";
        public string DB_User = "firmovac";
        public string DB_Schema = "crmskchccz";

    }
}
