using Microsoft.EntityFrameworkCore;

namespace Firmovac.DataDefinitions
{
    public class Firma
    {
        public int Id { get; set; }
        public string Nazev { get; set; }

        /// <summary>
        /// Kontakty firmy
        /// </summary>
        public FirmaContact[] Kontakty { get; set; }        
        public OborDefinition Obor { get; set; }
        public FirmaSource? Zdroj { get; set; }
        public string? Poznamka { get; set; }

        /// <summary>
        /// Eventy firmy
        /// </summary>
        FirmaEvent[] Eventy { get; set; }

        string? JsonColumns { get; set; }

    }
}
