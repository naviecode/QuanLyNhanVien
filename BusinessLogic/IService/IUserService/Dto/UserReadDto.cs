using Data.Entities;

namespace BusinessLogic.IService.IUserService.Dto
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public int RoleID { get; set; }
        public Roles Role { get; set; }
    }
}
