using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Acme.HelpDesk.Web;
using Acme.HelpDesk.Web.Menus;
using Volo.Abp;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Acme.HelpDesk
{
    [DependsOn(
        typeof(AbpAspNetCoreTestBaseModule),
        typeof(HelpDeskWebModule),
        typeof(HelpDeskApplicationTestModule)
    )]
    public class HelpDeskWebTestModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<IMvcBuilder>(builder =>
            {
                builder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(HelpDeskWebModule).Assembly));
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalizationServices(context.Services);
            ConfigureNavigationServices(context.Services);
        }

        private static void ConfigureLocalizationServices(IServiceCollection services)
        {
            var cultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("tr") };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }

        private static void ConfigureNavigationServices(IServiceCollection services)
        {
            services.Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new HelpDeskMenuContributor());
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            //app.UseErrorPage();

            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}