using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.IService.IUserService.Dto
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public int RoleID { get; set; }
    }
}
