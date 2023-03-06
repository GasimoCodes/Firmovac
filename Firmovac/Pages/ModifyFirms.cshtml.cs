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

        [BindProperty(SupportsGet = true)]
        public int FirmId { get; set; }
        public Firma firmaModify { get; set; }
        public string headerText;

        public OborDefinition[] OborDefinitions;
        public FirmaSource[] FirmaSources;

        public ModifyFirmsModel(ILogger<ModifyFirmsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (FirmaDbContext dBContext = new FirmaDbContext())
            {
                firmaModify = dBContext.Firms.Include("Obor").Include("Source").Include(p => p.Contact).Where(x => (x.Id == FirmId)).Include(p => p.Events).Where(x => (x.Id == FirmId)).SingleOrDefault();
                headerText = "Edit Firmy";

                // If no firma, create new 
                if (firmaModify == null)
                    createBlankFirma();

                OborDefinitions = FirmaDBRepository.GetDefinitions(dBContext);
                FirmaSources = FirmaDBRepository.GetSources(dBContext);

            }
        }

        private void createBlankFirma()
        {
            headerText = "Nová firma";

            // Firma doesnt exist, create
            firmaModify = new Firma()
            {
                Name = "Nová Firma",
                Contact = new List<FirmaContact> { new FirmaContact() {Name="Kontakt", Email="example@mail.com"} },
            };
        }


        public void OnPost()
        {

        }

    }
}