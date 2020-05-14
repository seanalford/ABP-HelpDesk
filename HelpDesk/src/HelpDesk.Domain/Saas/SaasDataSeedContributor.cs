using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Saas;

namespace HelpDesk.Saas
{
    public class SaasDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IEditionDataSeeder _editionDataSeeder;

        public SaasDataSeedContributor(IEditionDataSeeder editionDataSeeder)
        {
            _editionDataSeeder = editionDataSeeder;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await _editionDataSeeder.CreateStandardEditionsAsync();
        }
    }
}
