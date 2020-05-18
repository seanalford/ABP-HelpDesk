using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Acme.HelpDesk.Organizations;
using Acme.HelpDesk.Shared;

namespace Acme.HelpDesk.Web.Pages.Organizations
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }
        public string NumberFilter { get; set; }
        public string StreetFilter { get; set; }
        public string CityFilter { get; set; }
        public string StateFilter { get; set; }
        public string ZipcodeFilter { get; set; }
        public string PhoneFilter { get; set; }
        public string FaxFilter { get; set; }
        public string NotesFilter { get; set; }

        private readonly IOrganizationAppService _organizationAppService;

        public IndexModel(IOrganizationAppService organizationAppService)
        {
            _organizationAppService = organizationAppService;
        }

        public async Task OnGetAsync()
        {

        }
    }
}