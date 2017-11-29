using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseBridge.Models
{
    [Table("Elves")]
    public class Elf : NwcLib.EntityFrameworkGenerics.GenericModel
    {
        [Column("ElfID")]
        [Required]
        [Key]
        public override int ID { get; set; }

        [Column("Name")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Column("YearsOnJob")]
        [Required]
        public int YearsOnJob { get; set; }

        [Column("Salary")]
        [Required]
        public int Salary { get; set; }

        [Column("Rank")]
        [Required]
        public int Rank { get; set; }
    }
}
