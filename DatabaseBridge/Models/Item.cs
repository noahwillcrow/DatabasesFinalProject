using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseBridge.Models
{
    [Table("Items")]
    public class Item : NwcLib.EntityFrameworkGenerics.GenericModel
    {
        [Column("ItemID")]
        [Required]
        [Key]
        public override int ID { get; set; }

        [Column("Name")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
    }
}
