using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Firmovac.DataDefinitions
{
    [Index(nameof(Name), IsUnique = false)]
    public class FirmaEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public DateTime EventDate { get; set; }

    }
}
