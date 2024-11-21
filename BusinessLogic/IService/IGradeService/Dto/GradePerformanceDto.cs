using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IGradeService.Dto
{
    public class GradePerformanceDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double? AverageGrade { get; set; }
        public string Classification { get; set; }
    }
}
