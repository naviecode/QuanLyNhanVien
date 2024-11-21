using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IClassService.Dto
{
    public class AddCourseToClassDto
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public int FacultyId { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
    }
}
