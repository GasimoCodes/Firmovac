﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firmovac.DataDefinitions
{
    [Index(nameof(Name), IsUnique = false)]
    public class Firma
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Kontakty firmy
        /// </summary>
        public FirmaContact[] Contact { get; set; }        
        public OborDefinition Obor { get; set; }
        public FirmaSource? Source { get; set; }
        public string? Note { get; set; }

        /// <summary>
        /// Eventy firmy
        /// </summary>
        FirmaEvent[]? Events { get; set; }

        string? JsonColumns { get; set; }

    }
}
