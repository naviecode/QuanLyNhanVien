namespace BusinessLogic.IService.IUserService.Dto
{
    public class UserReadDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
