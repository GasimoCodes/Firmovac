using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firmovac.DataDefinitions
{
    /// <summary>
    /// Definition oboru, IT/ELE/AM
    /// </summary>
    public class OborDefinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
