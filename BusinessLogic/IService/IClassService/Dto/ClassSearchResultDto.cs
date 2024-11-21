using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IClassService.Dto
{
    public class ClassSearchResultDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string DepartmentName { get; set; } 
    }
}
