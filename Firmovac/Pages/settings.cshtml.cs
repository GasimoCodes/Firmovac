using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Firmovac.Pages
{
    public class SettingsModel : PageModel
    {

        [BindProperty]
		[Display(Name = "SMTP Adresa")]
		public string SMTP_Address { get; set; }
        public void OnGet()
        {

        }
    }
}
