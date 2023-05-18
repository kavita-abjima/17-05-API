using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentsDetails.Models
{
    public partial class StudentsDetailDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string FamilyName { get; set; } = null!;


        [MaxLength(200)]
        public string Address { get; set; } = null!;

        [Required]
        public long ContactNumber { get; set; }
    }
}
