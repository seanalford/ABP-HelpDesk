using Volo.Abp.Application.Dtos;
using System;

namespace Acme.HelpDesk.Organizations
{
    public class GetOrganizationsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Notes { get; set; }

        public GetOrganizationsInput()
        {

        }
    }
}