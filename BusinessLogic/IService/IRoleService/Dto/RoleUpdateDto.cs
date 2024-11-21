using Data.Entities;

namespace BusinessLogic.IService.IRoleService.Dto
{
    public class RoleUpdateDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<Users> Users { get; set; } = new List<Users>();
        public ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();
    }
}
