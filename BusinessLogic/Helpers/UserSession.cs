using Data.Entities;

namespace BusinessLogic.Helpers
{
    public static class UserSession
    {
        public static List<RolePermissions> Permissions { get; private set; }
        public static string Username { get; set; }

        public static void Initialize(List<RolePermissions> permissions)
        {
            Permissions = permissions;
        }

        //public static bool HasPermission(string permission)
        //{
        //    return Permissions.Contains(permission);
        //}

        public static void Clear()
        {
            Username = null;
            Permissions = null;
        }
    }
}
