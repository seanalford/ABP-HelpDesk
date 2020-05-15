using System.Threading.Tasks;

namespace Acme.HelpDesk.Data
{
    public interface IHelpDeskDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}