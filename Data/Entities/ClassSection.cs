using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ClassSection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int FacultyId { get; set; }
        [Required]
        public string Semester { get; set; }
        [Required]
        public int Year { get; set; }

        public Course Course { get; set; }
        public Faculty Faculty { get; set; }
    }
}
