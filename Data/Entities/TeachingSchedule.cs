using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class TeachingSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseScheduleId { get; set; }
        [Required] 
        public string StartAndEndTime { get; set; } 

        public DateTime Date { get; set; } 
        [ForeignKey("Faculty")]
        public int? FacultyScheduleId { get; set; }
        public string Room { get; set; }
        // Navigation properties
        public Course Course { get; set; }
        public Faculty Faculty { get; set; }
    }
}
