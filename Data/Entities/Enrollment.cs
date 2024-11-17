using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }  
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public decimal? Grade { get; set; }

        public Students Student { get; set; }
        public Course Course { get; set; }
    }
}
