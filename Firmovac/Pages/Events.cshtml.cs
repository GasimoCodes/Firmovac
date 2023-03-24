using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Firmovac.DataDefinitions;

namespace Firmovac.Pages
{
    public class EventsModel : PageModel
    {
        private readonly ILogger<EventsModel> _logger;
        
        public FirmaEvent[] FirmaSources;


        public EventsModel(ILogger<EventsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Ziskat list eventu

        }
    }
}