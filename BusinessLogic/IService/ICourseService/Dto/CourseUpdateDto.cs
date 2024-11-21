using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.ICourseService.Dto
{
    public class CourseUpdateDto
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public DateTime StartRegisterDate { get; set; }
        [Required]
        public DateTime EndRegisterDate { get; set; }
        [Required]
        public int MaxAmountRegist { get; set; }
    }
}
