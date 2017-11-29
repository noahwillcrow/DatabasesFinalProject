using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseBridge.Models
{
    [Table("Kids")]
    public class Kid : NwcLib.EntityFrameworkGenerics.GenericModel
    {
        [Column("KidID")]
        [Required]
        [Key]
        public override int ID { get; set; }

        [Column("HouseID")]
        [Required]
        public int HouseID { get; set; }

        [Column("Name")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Column("Gender")]
        [MaxLength(5)]
        [Required]
        public string Gender { get; set; }

        [Column("Age")]
        [Required]
        public int Age { get; set; }
    }
}
