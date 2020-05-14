namespace HelpDesk.Permissions
{
    public static class HelpDeskPermissions
    {
        public const string GroupName = "HelpDesk";

        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = GroupName + ".Tenant";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
    }
}