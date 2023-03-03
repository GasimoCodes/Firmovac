using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Firmovac.Pages
{
    public class EventsModel : PageModel
    {
        private readonly ILogger<EventsModel> _logger;

        public EventsModel(ILogger<EventsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}