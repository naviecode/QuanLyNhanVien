using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ClassSection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public int FacultyId { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }

        public Course Course { get; set; }
        public Faculty Faculty { get; set; }
    }
}
