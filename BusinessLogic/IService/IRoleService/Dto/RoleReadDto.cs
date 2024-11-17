using BusinessLogic.IService.IUserService.Dto;

namespace BusinessLogic.IService.IRoleService.Dto
{
    public class RoleReadDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserReadDto> Users { get; set; } = new List<UserReadDto>();
        //public ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();
    }
}
