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
using Acme.HelpDesk.Organizations;

namespace Acme.HelpDesk.Organizations
{
    [Authorize(HelpDeskPermissions.Organizations.Default)]
    public class OrganizationAppService : ApplicationService, IOrganizationAppService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationAppService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;

        }

        public virtual async Task<PagedResultDto<OrganizationDto>> GetListAsync(GetOrganizationsInput input)
        {
            var totalCount = await _organizationRepository.GetCountAsync(input.FilterText, input.Name, input.Number, input.Street, input.City, input.State, input.Zipcode, input.Phone, input.Fax, input.Notes);
            var items = await _organizationRepository.GetListAsync(input.FilterText, input.Name, input.Number, input.Street, input.City, input.State, input.Zipcode, input.Phone, input.Fax, input.Notes, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<OrganizationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Organization>, List<OrganizationDto>>(items)
            };
        }

        public virtual async Task<OrganizationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Organization, OrganizationDto>(await _organizationRepository.GetAsync(id));
        }

        [Authorize(HelpDeskPermissions.Organizations.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _organizationRepository.DeleteAsync(id);
        }

        [Authorize(HelpDeskPermissions.Organizations.Create)]
        public virtual async Task<OrganizationDto> CreateAsync(OrganizationCreateDto input)
        {
            var newOrganization = ObjectMapper.Map<OrganizationCreateDto, Organization>(input);
            newOrganization.TenantId = CurrentTenant.Id;
            var organization = await _organizationRepository.InsertAsync(newOrganization);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<Organization, OrganizationDto>(organization);
        }

        [Authorize(HelpDeskPermissions.Organizations.Edit)]
        public virtual async Task<OrganizationDto> UpdateAsync(Guid id, OrganizationUpdateDto input)
        {
            var organization = await _organizationRepository.GetAsync(id);
            ObjectMapper.Map(input, organization);
            var updatedOrganization = await _organizationRepository.UpdateAsync(organization);
            return ObjectMapper.Map<Organization, OrganizationDto>(updatedOrganization);
        }
    }
}