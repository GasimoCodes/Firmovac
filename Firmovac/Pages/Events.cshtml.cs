using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Firmovac.DataDefinitions;

namespace Firmovac.Pages
{
    public class EventsModel : PageModel
    {
        private readonly ILogger<EventsModel> _logger;

        public FirmaEvent[] firmaEventy;

        [BindProperty(SupportsGet = true)]
        public bool showOldEvents { get; set; }

        public EventsModel(ILogger<EventsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Ziskat list eventu
            using (FirmaDbContext dBContext = new FirmaDbContext())
            {

                if (showOldEvents)
                    firmaEventy = dBContext.FirmaEvents.OrderByDescending(x => x.EventDate).ToArray();
                else
                    firmaEventy = dBContext.FirmaEvents.Where(x => x.EventDate >= System.DateTime.Now).OrderByDescending(x => x.EventDate).ToArray();


            }

        }
    }
}