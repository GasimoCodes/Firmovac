using Firmovac.DataDefinitions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Firmovac.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Firma[] firmy;
        public int firmaIndex = 1;


        [BindProperty(SupportsGet = true)]
        public string searchQuery { get; set; }

        [BindProperty]
        public int[] listRemoveFirm { get; set; }


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


        [HttpPost]
        public void OnPost([FromBody] Object data)
        {
            // Access the parameters here
            if (data != null)
            {
                JObject jO = JObject.Parse(data.ToString());

                int[] firmsIds = jO["listPrintFirm"].ToObject<int[]>();
                int command = jO["command"].ToObject<int>();

                switch(command)
                {
                    // Display CSV
                    case 0:
                        {
                            break;
                        }
                    // Delete
                    case 1:
                        {
                            break;
                        }
                }

            }

        }
    }
}