using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.HelpDesk.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.HelpDesk.EntityFrameworkCore
{
    public class EntityFrameworkCoreHelpDeskDbSchemaMigrator
        : IHelpDeskDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreHelpDeskDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the HelpDeskMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<HelpDeskMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}