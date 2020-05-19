using Volo.Abp.Application.Dtos;
using System;

namespace Acme.HelpDesk.Tags
{
    public class GetTagsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }

        public GetTagsInput()
        {

        }
    }
}