using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firmovac.DataDefinitions
{
    /// <summary>
    /// Zdroj firmy (IT/PRAXE ZAKU/Prac. Nabídka z Port...)
    /// </summary>
    public class FirmaSource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
