using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Acme.HelpDesk.Data;
using Serilog;
using Serilog.Events;
using Volo.Abp;
using Volo.Abp.Threading;

namespace Acme.HelpDesk.DbMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogging();

            try
            {
                using (var application = AbpApplicationFactory.Create<HelpDeskDbMigratorModule>(options =>
                {
                    options.UseAutofac();
                    options.Services.AddLogging(c => c.AddSerilog());
                }))
                {
                    application.Initialize();

                    AsyncHelper.RunSync(
                        () => application
                            .ServiceProvider
                            .GetRequiredService<HelpDeskDbMigrationService>()
                            .MigrateAsync()
                    );

                    application.Shutdown();
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                Console.WriteLine(e);
            }
        }

        private static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning)
#if DEBUG
                .MinimumLevel.Override("Acme.HelpDesk", LogEventLevel.Debug)
#else
                .MinimumLevel.Override("Acme.HelpDesk", LogEventLevel.Information)
#endif
                .Enrich.FromLogContext()
                .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/logs.txt"))
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}