using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Acme.HelpDesk.EntityFrameworkCore
{
    [DependsOn(
        typeof(HelpDeskEntityFrameworkCoreModule)
    )]
    public class HelpDeskEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HelpDeskMigrationsDbContext>();
        }
    }
}