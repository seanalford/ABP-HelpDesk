using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Acme.HelpDesk.Organizations;

namespace Acme.HelpDesk.Web.Pages.Organizations
{
    public class CreateModalModel : HelpDeskPageModel
    {
        [BindProperty]
        public OrganizationCreateDto Organization { get; set; }

        private readonly IOrganizationAppService _organizationAppService;

        public CreateModalModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }

        public async Task OnGetAsync()
        {
            Organization = new OrganizationCreateDto();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _organizationAppService.CreateAsync(Organization);
            return NoContent();
        }
    }
}