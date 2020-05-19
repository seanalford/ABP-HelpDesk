using System;
using Volo.Abp.Application.Dtos;

namespace Acme.HelpDesk.Tags
{
    public class TagDto : FullAuditedEntityDto<Guid>
    {

        public string Name { get; set; }

    }
}