using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IClassService.Dto
{
    public class ClassByIdDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string CourseName { get; set; }
        public string FacultyName { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
    }
}
