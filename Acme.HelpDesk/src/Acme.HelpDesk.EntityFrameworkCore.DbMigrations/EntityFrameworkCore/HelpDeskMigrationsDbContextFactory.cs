using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Acme.HelpDesk.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class HelpDeskMigrationsDbContextFactory : IDesignTimeDbContextFactory<HelpDeskMigrationsDbContext>
    {
        public HelpDeskMigrationsDbContext CreateDbContext(string[] args)
        {
            HelpDeskEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HelpDeskMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new HelpDeskMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
