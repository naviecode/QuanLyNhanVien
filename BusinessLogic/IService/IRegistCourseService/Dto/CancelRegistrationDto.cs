using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IRegistCourseService.Dto
{
    public class CancelRegistrationDto
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }
}
