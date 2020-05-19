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

            var organizationPermission = myGroup.AddPermission(HelpDeskPermissions.Organizations.Default, L("Permission:Organizations"));
            organizationPermission.AddChild(HelpDeskPermissions.Organizations.Create, L("Permission:Create"));
            organizationPermission.AddChild(HelpDeskPermissions.Organizations.Edit, L("Permission:Edit"));
            organizationPermission.AddChild(HelpDeskPermissions.Organizations.Delete, L("Permission:Delete"));

            var tagPermission = myGroup.AddPermission(HelpDeskPermissions.Tags.Default, L("Permission:Tags"));
            tagPermission.AddChild(HelpDeskPermissions.Tags.Create, L("Permission:Create"));
            tagPermission.AddChild(HelpDeskPermissions.Tags.Edit, L("Permission:Edit"));
            tagPermission.AddChild(HelpDeskPermissions.Tags.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HelpDeskResource>(name);
        }
    }
}