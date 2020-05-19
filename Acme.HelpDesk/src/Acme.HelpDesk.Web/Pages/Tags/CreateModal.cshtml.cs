using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Acme.HelpDesk.Tags;

namespace Acme.HelpDesk.Web.Pages.Tags
{
    public class CreateModalModel : HelpDeskPageModel
    {
        [BindProperty]
        public TagCreateDto Tag { get; set; }

        private readonly ITagAppService _tagAppService;

        public CreateModalModel(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public async Task OnGetAsync()
        {
            Tag = new TagCreateDto();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _tagAppService.CreateAsync(Tag);
            return NoContent();
        }
    }
}