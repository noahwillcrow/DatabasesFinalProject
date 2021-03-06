﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseBridge.Models
{
    [Table("Deeds")]
    public class Deed
    {
        [Column("KidID", Order = 1)]
        [Required]
        [Key]
        public int KidID { get; set; }

        [Column("TimeOfDeed", Order = 2)]
        [Required]
        [Key]
        public DateTime TimeOfDeed { get; set; }

        [Column("Description")]
        [MaxLength(200)]
        [Required]
        public string Description { get; set; }

        [Column("Weight")]
        [Required]
        public int Weight { get; set; }

        [Column("IsNice")]
        [Required]
        public bool IsNice { get; set; }
    }
}
