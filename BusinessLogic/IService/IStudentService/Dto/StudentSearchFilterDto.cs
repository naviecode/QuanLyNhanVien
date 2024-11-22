using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IStudentService.Dto
{
    public class StudentSearchFilterDto
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? UserId { get; set; }
        public string ClassName { get; set; }
        public string HomeTown { get; set; }
    }
}
