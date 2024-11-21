using Data.Entities;

namespace BusinessLogic.IService.IPermissions.Dto
{
    public class PermissionsUpdateDto
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();
    }
}
