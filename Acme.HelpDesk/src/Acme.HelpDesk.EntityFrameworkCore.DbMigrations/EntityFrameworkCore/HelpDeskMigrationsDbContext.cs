using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;

namespace Acme.HelpDesk.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See HelpDeskDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class HelpDeskMigrationsDbContext : AbpDbContext<HelpDeskMigrationsDbContext>
    {
        public HelpDeskMigrationsDbContext(DbContextOptions<HelpDeskMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureLanguageManagement();
            builder.ConfigureSaas();
            builder.ConfigureTextTemplateManagement();

            /* Configure your own tables/entities inside the ConfigureHelpDesk method */

            builder.ConfigureHelpDesk();
        }
    }
}