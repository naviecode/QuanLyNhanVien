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

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
