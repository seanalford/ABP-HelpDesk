namespace Acme.HelpDesk.Permissions
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

        public class Organizations
        {
            public const string Default = GroupName + ".Organizations";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Tags
        {
            public const string Default = GroupName + ".Tags";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}