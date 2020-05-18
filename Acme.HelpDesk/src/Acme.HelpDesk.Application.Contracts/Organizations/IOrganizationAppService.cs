using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.HelpDesk.Organizations
{
    public interface IOrganizationAppService : IApplicationService
    {
        Task<PagedResultDto<OrganizationDto>> GetListAsync(GetOrganizationsInput input);

        Task<OrganizationDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<OrganizationDto> CreateAsync(OrganizationCreateDto input);

        Task<OrganizationDto> UpdateAsync(Guid id, OrganizationUpdateDto input);
    }
}