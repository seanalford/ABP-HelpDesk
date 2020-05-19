using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Acme.HelpDesk.Tags;

namespace Acme.HelpDesk.Web.Pages.Tags
{
    public class EditModalModel : HelpDeskPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public TagUpdateDto Tag { get; set; }

        private readonly ITagAppService _tagAppService;

        public EditModalModel(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        public async Task OnGetAsync()
        {
            var tag = await _tagAppService.GetAsync(Id);
            Tag = ObjectMapper.Map<TagDto, TagUpdateDto>(tag);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _tagAppService.UpdateAsync(Id, Tag);
            return NoContent();
        }
    }
}