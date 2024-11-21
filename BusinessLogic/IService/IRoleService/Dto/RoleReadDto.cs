using BusinessLogic.IService.IRolePermissions.Dto;
using BusinessLogic.IService.IUserService.Dto;

namespace BusinessLogic.IService.IRoleService.Dto
{
    public class RoleReadDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserReadDto> Users { get; set; } = new List<UserReadDto>();
        public ICollection<RolePermissionsReadDto> RolePermissions { get; set; } = new List<RolePermissionsReadDto>();
    }
}
