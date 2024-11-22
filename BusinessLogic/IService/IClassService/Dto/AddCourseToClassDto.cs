using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IClassService.Dto
{
    public class AddCourseToClassDto
    {
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
    }
}
