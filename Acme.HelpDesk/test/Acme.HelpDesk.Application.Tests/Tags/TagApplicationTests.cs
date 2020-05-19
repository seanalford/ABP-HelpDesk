using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Acme.HelpDesk.Tags
{
    public class TagAppServiceTests : HelpDeskApplicationTestBase
    {
        private readonly ITagAppService _tagAppService;
        private readonly IRepository<Tag, Guid> _tagRepository;

        public TagAppServiceTests()
        {
            _tagAppService = GetRequiredService<ITagAppService>();
            _tagRepository = GetRequiredService<IRepository<Tag, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tagAppService.GetListAsync(new GetTagsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("58af2a8d-133d-456c-aff0-1cfa504ed7b8")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("20877d43-97b8-4b25-934c-bf87b7f55318")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tagAppService.GetAsync(Guid.Parse("58af2a8d-133d-456c-aff0-1cfa504ed7b8"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("58af2a8d-133d-456c-aff0-1cfa504ed7b8"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TagCreateDto
            {
                Name = "40cfea20f3034ca7890cb2476"
            };

            // Act
            var serviceResult = await _tagAppService.CreateAsync(input);

            // Assert
            var result = await _tagRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("40cfea20f3034ca7890cb2476");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TagUpdateDto()
            {
                Name = "16bfacdbdc1248f2889b73023"
            };

            // Act
            var serviceResult = await _tagAppService.UpdateAsync(Guid.Parse("58af2a8d-133d-456c-aff0-1cfa504ed7b8"), input);

            // Assert
            var result = await _tagRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("16bfacdbdc1248f2889b73023");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tagAppService.DeleteAsync(Guid.Parse("d23b946e-4d38-458b-8e7f-ceff522131f8"));

            // Assert
            var result = await _tagRepository.FindAsync(c => c.Id == Guid.Parse("d23b946e-4d38-458b-8e7f-ceff522131f8"));

            result.ShouldBeNull();
        }
    }
}