using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IRegistCourseService.Dto
{
    public class RegisteredCourseDto
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
    }
}
