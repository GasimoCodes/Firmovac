using Firmovac.DataDefinitions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Firmovac.DataDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Firmovac.Pages
{
    public class ModifyFirmsModel : PageModel
    {
        private readonly ILogger<ModifyFirmsModel> _logger;

        public Firma[] firmy;

        [BindProperty(SupportsGet = true)]
        public int FirmId { get; set; }

        public ModifyFirmsModel(ILogger<ModifyFirmsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (FirmaDbContext dBContext = new FirmaDbContext())
            {
                firmy = dBContext.Firms.Include("Obor").Include("Source").ToArray();
            }
        }

        public void OnPost()
        {

        }

    }
}