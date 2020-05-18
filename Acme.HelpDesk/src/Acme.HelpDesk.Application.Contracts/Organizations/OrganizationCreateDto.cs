using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.HelpDesk.Organizations
{
    public class OrganizationCreateDto
    {

        [Required]
        [StringLength(OrganizationConsts.NameMaxLength)]
        public string Name { get; set; }

        [StringLength(OrganizationConsts.NumberMaxLength)]
        public string Number { get; set; }

        [StringLength(OrganizationConsts.StreetMaxLength)]
        public string Street { get; set; }

        [StringLength(OrganizationConsts.CityMaxLength)]
        public string City { get; set; }

        [StringLength(OrganizationConsts.StateMaxLength)]
        public string State { get; set; }

        [StringLength(OrganizationConsts.ZipcodeMaxLength)]
        public string Zipcode { get; set; }

        [StringLength(OrganizationConsts.PhoneMaxLength)]
        public string Phone { get; set; }

        [StringLength(OrganizationConsts.FaxMaxLength)]
        public string Fax { get; set; }

        [StringLength(OrganizationConsts.NotesMaxLength)]
        public string Notes { get; set; }

    }
}