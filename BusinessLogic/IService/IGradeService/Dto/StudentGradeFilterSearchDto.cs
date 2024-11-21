using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IGradeService.Dto
{
    public class StudentGradeFilterSearchDto
    {
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public decimal? Grade { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
    }
}
