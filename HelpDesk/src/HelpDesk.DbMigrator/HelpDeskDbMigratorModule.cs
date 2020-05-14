using HelpDesk.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace HelpDesk.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(HelpDeskEntityFrameworkCoreDbMigrationsModule),
        typeof(HelpDeskApplicationContractsModule)
    )]
    public class HelpDeskDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}