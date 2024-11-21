using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IFacultyService.Dto
{
    public class FacultyUpdateDto
    {
        public int FacultyId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int DepartmentID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
