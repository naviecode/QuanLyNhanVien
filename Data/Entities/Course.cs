using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public DateTime StartRegisterDate { get; set; }
        [Required]
        public DateTime EndRegisterDate { get; set; }
        [Required]
        public int MaxAmountRegist { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<ClassSection> Classes { get; set; }
    }
}
