using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseBridge.Models
{
    [Table("Reindeer")]
    public class Reindeer : NwcLib.EntityFrameworkGenerics.GenericModel
    {
        [Column("ReindeerID")]
        [Required]
        [Key]
        public override int ID { get; set; }

        [Column("CaretakerElfID")]
        [Required]
        public int CaretakerElfID { get; set; }

        [Column("Name")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Column("Status")]
        [MaxLength(20)]
        [Required]
        public string Status { get; set; }
    }
}
