using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Acme.HelpDesk.Tags;

namespace Acme.HelpDesk.Tags
{
    public class TagsDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ITagRepository _tagRepository;

        public TagsDataSeedContributor(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _tagRepository.InsertAsync(new Tag
            (
                id: Guid.Parse("58af2a8d-133d-456c-aff0-1cfa504ed7b8"),
                name: "4541071796e94c0dbe9e736b7"
            ));

            await _tagRepository.InsertAsync(new Tag
            (
                id: Guid.Parse("20877d43-97b8-4b25-934c-bf87b7f55318"),
                name: "afb0b8f85d9c41938299ca791"
            ));
        }
    }
}