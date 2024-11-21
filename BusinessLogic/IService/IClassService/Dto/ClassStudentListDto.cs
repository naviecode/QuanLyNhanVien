using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IClassService.Dto
{
    public class ClassStudentListDto
    {
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
    }
}
