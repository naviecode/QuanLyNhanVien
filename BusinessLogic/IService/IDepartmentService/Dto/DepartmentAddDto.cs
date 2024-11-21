using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IDepartmentService.Dto
{
    public class DepartmentAddDto
    {
        [Required]
        public string DepartmentName { get; set; }
    }
}
