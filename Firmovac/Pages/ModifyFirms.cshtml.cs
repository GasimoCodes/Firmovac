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
        private readonly ILogger<IndexModel> _logger;

        public Firma[] firmy;


        public ModifyFirmsModel(ILogger<IndexModel> logger)
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

    }
}