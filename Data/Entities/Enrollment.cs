using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public decimal? Grade { get; set; }
        public bool? IsCanceled { get; set; }

        public Students Student { get; set; }
        public Course Course { get; set; }
    }
}
