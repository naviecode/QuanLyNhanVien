using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Class
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string ClassName { get; set; }
        public int CourseID { get; set; }
        public int FacultyID { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }

        public Course Course { get; set; }
        public Faculty Faculty { get; set; }
    }
}
