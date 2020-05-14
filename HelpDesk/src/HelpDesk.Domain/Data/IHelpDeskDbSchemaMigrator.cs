using System.Threading.Tasks;

namespace HelpDesk.Data
{
    public interface IHelpDeskDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}