using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.IService.IUserService.Dto
{
    public class UserUpdateDto
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleID { get; set; }
    }
}
