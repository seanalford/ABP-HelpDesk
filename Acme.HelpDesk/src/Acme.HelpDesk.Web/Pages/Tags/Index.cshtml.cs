using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Acme.HelpDesk.Tags;
using Acme.HelpDesk.Shared;

namespace Acme.HelpDesk.Web.Pages.Tags
{
    public class IndexModel : AbpPageModel
    {
        public string NameFilter { get; set; }

        private readonly ITagAppService _tagAppService;

        public IndexModel(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public async Task OnGetAsync()
        {

        }
    }
}