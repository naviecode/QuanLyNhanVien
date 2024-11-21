using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IRegistCourseService.Dto
{
    public class CourseRegistrationDto
    {
        public int StudentId {  get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
    }
}
