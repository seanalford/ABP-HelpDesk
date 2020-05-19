using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Acme.HelpDesk.Permissions;
using Acme.HelpDesk.Tags;

namespace Acme.HelpDesk.Tags
{
    [Authorize(HelpDeskPermissions.Tags.Default)]
    public class TagAppService : ApplicationService, ITagAppService
    {
        private readonly ITagRepository _tagRepository;

        public TagAppService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;

        }

        public virtual async Task<PagedResultDto<TagDto>> GetListAsync(GetTagsInput input)
        {
            var totalCount = await _tagRepository.GetCountAsync(input.FilterText, input.Name);
            var items = await _tagRepository.GetListAsync(input.FilterText, input.Name, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TagDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Tag>, List<TagDto>>(items)
            };
        }

        public virtual async Task<TagDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Tag, TagDto>(await _tagRepository.GetAsync(id));
        }

        [Authorize(HelpDeskPermissions.Tags.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _tagRepository.DeleteAsync(id);
        }

        [Authorize(HelpDeskPermissions.Tags.Create)]
        public virtual async Task<TagDto> CreateAsync(TagCreateDto input)
        {
            var newTag = ObjectMapper.Map<TagCreateDto, Tag>(input);
            newTag.TenantId = CurrentTenant.Id;
            var tag = await _tagRepository.InsertAsync(newTag);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<Tag, TagDto>(tag);
        }

        [Authorize(HelpDeskPermissions.Tags.Edit)]
        public virtual async Task<TagDto> UpdateAsync(Guid id, TagUpdateDto input)
        {
            var tag = await _tagRepository.GetAsync(id);
            ObjectMapper.Map(input, tag);
            var updatedTag = await _tagRepository.UpdateAsync(tag);
            return ObjectMapper.Map<Tag, TagDto>(updatedTag);
        }
    }
}