using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.IService.IUserService.Dto
{
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleID { get; set; }
    }
}
