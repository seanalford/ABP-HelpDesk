using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Acme.HelpDesk.Organizations;

namespace Acme.HelpDesk.Web.Pages.Organizations
{
    public class EditModalModel : HelpDeskPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public OrganizationUpdateDto Organization { get; set; }

        private readonly IOrganizationAppService _organizationAppService;

        public EditModalModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }

        public async Task OnGetAsync()
        {
            var organization = await _organizationAppService.GetAsync(Id);
            Organization = ObjectMapper.Map<OrganizationDto, OrganizationUpdateDto>(organization);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _organizationAppService.UpdateAsync(Id, Organization);
            return NoContent();
        }
    }
}