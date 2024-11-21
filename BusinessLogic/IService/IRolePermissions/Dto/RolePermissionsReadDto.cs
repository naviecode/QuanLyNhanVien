using Data.Entities;

namespace BusinessLogic.IService.IRolePermissions.Dto
{
    public class RolePermissionsReadDto
    {
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public Roles Role { get; set; }
        public Permissions Permission { get; set; }
    }
}
