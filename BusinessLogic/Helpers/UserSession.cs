using BusinessLogic.IService.IRolePermissions.Dto;
using Data.Entities;

namespace BusinessLogic.Helpers
{
    public static class UserSession
    {
        public static List<RolePermissionsReadDto> Permissions { get; private set; }
        public static string Username { get; set; }
        public static string RoleName { get; set; }
        public static int UserId { get; set; }

        public static void Initialize(List<RolePermissionsReadDto> permissions)
        {
            Permissions = permissions;
        }

        public static bool HasPermission(int permissionId)
        {
            return Permissions.Any(x => x.PermissionID == permissionId);
        }

        public static bool HasPermissionName(string permissionName = "")
        {
            return Permissions.Any(x => x.Permission.PermissionName.ToUpper() == permissionName.ToUpper());
        }

        public static void Clear()
        {
            Username = null;
            Permissions = null;
        }
    }
}
