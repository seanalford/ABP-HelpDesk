using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Acme.HelpDesk.Tags;
using Acme.HelpDesk.EntityFrameworkCore;
using Xunit;

namespace Acme.HelpDesk.Tags
{
    public class TagRepositoryTests : HelpDeskEntityFrameworkCoreTestBase
    {
        private readonly ITagRepository _tagRepository;

        public TagRepositoryTests()
        {
            _tagRepository = GetRequiredService<ITagRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tagRepository.GetListAsync(
                    name: "4541071796e94c0dbe9e736b7"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("58af2a8d-133d-456c-aff0-1cfa504ed7b8"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tagRepository.GetCountAsync(
                    name: "afb0b8f85d9c41938299ca791"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}