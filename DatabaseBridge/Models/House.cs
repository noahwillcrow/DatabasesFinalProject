using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseBridge.Models
{
    [Table("Houses")]
    public class House : NwcLib.EntityFrameworkGenerics.GenericModel
    {
        [Column("HouseID")]
        [Required]
        [Key]
        public override int ID { get; set; }

        [Column("FamilyName")]
        [MaxLength(20)]
        [Required]
        public string FamilyName { get; set; }

        [Column("Address")]
        [MaxLength(200)]
        [Required]
        public string Address { get; set; }

        [Column("HasChimney")]
        [Required]
        public bool HasChimney { get; set; }
    }
}
