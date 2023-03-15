using Firmovac.DataDefinitions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Firmovac.DataDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;

namespace Firmovac.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Firma[] firmy;
        public int firmaIndex = 1;


        [BindProperty(SupportsGet = true)]
        public string searchQuery { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (FirmaDbContext dBContext = new FirmaDbContext())
            {
                if (searchQuery.IsNullOrEmpty())
                    firmy = dBContext.Firms.Include("Obor").Include("Source").Include(p => p.Contact).Include("Events").ToArray();
                else
                    firmy = dBContext.Firms.Include("Obor").Include("Source").Include(p => p.Contact).Include("Events").Where(x => x.Name.Contains(searchQuery)).ToArray();
            }
        }

        public int getIncrementFirma()
        {
            return firmaIndex++;
        }

        public string mamRadData()
        {
            string result = "";

            using (FirmaDbContext dBContext = new FirmaDbContext())
            {
                foreach (OborDefinition s in dBContext.Obors)
                {
                    result += s.Name + " ";
                }
            }

            return result;
        }
    }
}