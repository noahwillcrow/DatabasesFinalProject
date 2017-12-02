using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseBridge.Models
{
    [Table("Presents")]
    public class Present
    {
        [Column("KidID", Order = 1)]
        [Required]
        [Key]
        public int KidID { get; set; }

        [Column("ItemID", Order = 2)]
        [Required]
        [Key]
        public int ItemID { get; set; }

        [Column("ElfID")]
        [Required]
        public int ElfID { get; set; }

        [Column("IsDone")]
        [Required]
        public bool IsDone { get; set; }
    }
}
