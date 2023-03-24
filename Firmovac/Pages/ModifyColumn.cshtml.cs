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
    public class ModifyColumnModel : PageModel
    {
        private readonly ILogger<ModifyFirmsModel> _logger;

        [BindProperty(SupportsGet = true)]
        public int ColumnId { get; set; }
        public ColumnDefinition[]  columns { get; set; }
        public string headerText;

        public ModifyColumnModel(ILogger<ModifyFirmsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (FirmaDbContext dBContext = new FirmaDbContext())
            {
                columns = dBContext.ColumnDefinitions.ToArray();
                headerText = "Edit sloupců";

                // If no sloupec, create new 
                if (columns == null)
                {
                    ColumnDefinition columnModify = new ColumnDefinition()
                    {
                        Name = "Nový sloupec"       
                    };
                    columns = new ColumnDefinition[] { columnModify };
                }
            }
        }

        /// <summary>
        /// Save all incoming changes
        /// </summary>
        public void OnPost()
        {

        }

    }
}