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

        public Firma firmaModify { get; set; }
        public string headerText;

        public OborDefinition[] OborDefinitions;
        public FirmaSource[] FirmaSources;


        // - GET (+POST)
        [BindProperty(SupportsGet = true)]
        public int FirmId { get; set; }

        // - POST
        [BindProperty]
        public int firma_source { get; set; }
        
        [BindProperty]
        public string firma_name { get; set; }

        [BindProperty]
        public string firma_note { get; set; }

        [BindProperty]
        public int firma_obor { get; set; }

        [BindProperty]
        public List<FirmaContact> Kontakty { get; set; }

        [BindProperty]
        public bool firma_active { get; set; }


        public ModifyFirmsModel(ILogger<ModifyFirmsModel> logger)
        {
            _logger = logger;
        }

        // If we savin
        public void OnPost()
        {

            using (FirmaDbContext dBContext = new FirmaDbContext())
            {
                bool isNew = false;

                firmaModify = dBContext.Firms.Include("Obor").Include("Source").Include(p => p.Contact).Where(x => (x.Id == FirmId)).Include(p => p.Events).Where(x => (x.Id == FirmId)).SingleOrDefault();
                headerText = "Edit Firmy";
                
                // If no firma, create new 
                if (firmaModify == null)
                {
                    createBlankFirma();
                    isNew = true;
                }

                OborDefinitions = FirmaDBRepository.GetDefinitions(dBContext);
                FirmaSources = FirmaDBRepository.GetSources(dBContext);

                // Assign Firma Data From POST
                firmaModify.Name = firma_name;
                firmaModify.Note = firma_note;
                firmaModify.Source = FirmaSources.Where(x => (x.Id == firma_source)).SingleOrDefault();
                firmaModify.Obor = OborDefinitions.Where(x => (x.Id == firma_obor)).SingleOrDefault();
                firmaModify.isAktivni = firma_active;

                if(isNew)
                dBContext.Firms.Add(firmaModify);
                dBContext.SaveChanges();
            }

            Console.WriteLine(Response.Body);

            if (Kontakty != null)
            {
                foreach(FirmaContact fC in Kontakty)
                { 
                    
                }
            }

        }

        // If we displayin
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

                firma_active = firmaModify.isAktivni;

            }
        }

        private void createBlankFirma()
        {
            headerText = "Nová firma";

            // Firma doesnt exist, create
            firmaModify = new Firma()
            {
                Name = "Nová Firma",
                Contact = new List<FirmaContact> { new FirmaContact() { Name = "Kontakt", Email = "example@mail.com" } },
                isAktivni = true,
            };
        }


    }
}