using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Firmovac.Pages
{
    public class SettingsModel : PageModel
    {
        // Properties 

        [BindProperty]
		[Display(Name = "SMTP Adresa")]
		public string SMTP_Address { get; set; }

        [BindProperty]
        [Display(Name = "SMTP Heslo")]
        public string SMTP_Password { get; set; }

        [BindProperty]
        [Display(Name = "Admin Email")]
        public string Admin_Mail { get; set; }



        public void OnGet()
        {
            SMTP_Address = Utils.siteConfig.SMTP_Address;
            SMTP_Password= Utils.siteConfig.SMTP_Password;
            Admin_Mail = Utils.siteConfig.Admin_Email;
        }

        [HttpPost]
        public void OnPost()
        {
            Utils.siteConfig.SMTP_Address = SMTP_Address;
            Utils.siteConfig.SMTP_Password = SMTP_Password;
            Utils.siteConfig.Admin_Email = Admin_Mail;

            Utils.SaveConfig();
        }

    }
}
