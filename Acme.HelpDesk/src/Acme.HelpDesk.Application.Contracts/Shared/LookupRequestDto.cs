using Volo.Abp.Application.Dtos;

namespace Acme.HelpDesk.Shared
{
    public class LookupRequestDto : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}