using System;
using Volo.Abp.Application.Dtos;

namespace Acme.HelpDesk.Organizations
{
    public class OrganizationDto : FullAuditedEntityDto<Guid>
    {

        public string Name { get; set; }

        public string Number { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Notes { get; set; }

    }
}