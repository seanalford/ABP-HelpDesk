using Acme.HelpDesk.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acme.HelpDesk.Permissions
{
    public class HelpDeskPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HelpDeskPermissions.GroupName);

            myGroup.AddPermission(HelpDeskPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(HelpDeskPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(HelpDeskPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HelpDeskResource>(name);
        }
    }
}