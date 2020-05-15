using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Acme.HelpDesk.Localization;
using Acme.HelpDesk.Permissions;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.IdentityServer.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Saas.Host.Navigation;

namespace Acme.HelpDesk.Web.Menus
{
    public class HelpDeskMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<HelpDeskResource>>();

            //Home
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    HelpDeskMenus.Home,
                    l["Menu:Home"],
                    "/",
                    icon: "fa fa-home",
                    order: 1
                )
            );

            if (await authorizationService.IsGrantedAsync(HelpDeskPermissions.Dashboard.Host))
            {
                //HostDashboard
                context.Menu.AddItem(
                    new ApplicationMenuItem(
                        HelpDeskMenus.HostDashboard,
                        l["Menu:Dashboard"],
                        "/HostDashboard",
                        icon: "fa fa-line-chart",
                        order: 2
                    )
                );
            }

            if (await authorizationService.IsGrantedAsync(HelpDeskPermissions.Dashboard.Tenant))
            {
                //TenantDashboard
                context.Menu.AddItem(
                    new ApplicationMenuItem(
                        HelpDeskMenus.TenantDashboard,
                        l["Menu:Dashboard"],
                        "/Dashboard",
                        icon: "fa fa-line-chart",
                        order: 2
                    )
                );
            }

            //Administration
            var administration = context.Menu.GetAdministration();
            administration.Order = 3;

            //Administration->Saas
            administration.SetSubItemOrder(SaasHostMenuNames.GroupName, 1);

            //Administration->Identity
            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);

            //Administration->Identity Server
            administration.SetSubItemOrder(AbpIdentityServerMenuNames.GroupName, 3);

            //Administration->Language Management
            administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 4);

            //Administration->Text Template Management
            administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 5);

            //Administration->Audit Logs
            administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 6);

            //Administration->Settings
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);
        }
    }
}