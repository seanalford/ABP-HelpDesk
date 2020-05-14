using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HelpDesk.Data
{
    /* This is used if database provider does't define
     * IHelpDeskDbSchemaMigrator implementation.
     */
    public class NullHelpDeskDbSchemaMigrator : IHelpDeskDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}