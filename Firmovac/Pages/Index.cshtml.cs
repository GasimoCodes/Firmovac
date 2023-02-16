using Firmovac.DataDefinitions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Firmovac.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public string mamRadData()
        {
            string result = "";

            using (FirmaDbContext dBContext = new FirmaDbContext())
            {
                foreach(OborDefinition s in dBContext.Obors)
                {
                    result += s.Name + " ";
                }
            }

            return result;
        }
    }
}