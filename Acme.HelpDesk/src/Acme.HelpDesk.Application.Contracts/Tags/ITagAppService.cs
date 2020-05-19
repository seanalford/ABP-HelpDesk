using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.HelpDesk.Tags
{
    public interface ITagAppService : IApplicationService
    {
        Task<PagedResultDto<TagDto>> GetListAsync(GetTagsInput input);

        Task<TagDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TagDto> CreateAsync(TagCreateDto input);

        Task<TagDto> UpdateAsync(Guid id, TagUpdateDto input);
    }
}