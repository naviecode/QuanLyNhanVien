namespace BusinessLogic.Helpers
{
    public static class UserSession
    {
        public static List<string> Permissions { get; private set; }
        public static string Username { get; set; }

        public static void Initialize(List<string> permissions)
        {
            Permissions = permissions;
        }

        public static bool HasPermission(string permission)
        {
            return Permissions.Contains(permission);
        }
    }
}
