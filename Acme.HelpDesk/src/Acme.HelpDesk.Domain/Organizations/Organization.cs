using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Acme.HelpDesk.Organizations
{
    public class Organization : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {

        
        public virtual Guid? TenantId { get; set; }
        
        [NotNull]
        public virtual string Name { get; set; }
        
        [CanBeNull]
        public virtual string Number { get; set; }
        
        [CanBeNull]
        public virtual string Street { get; set; }
        
        [CanBeNull]
        public virtual string City { get; set; }
        
        [CanBeNull]
        public virtual string State { get; set; }
        
        [CanBeNull]
        public virtual string Zipcode { get; set; }
        
        [CanBeNull]
        public virtual string Phone { get; set; }
        
        [CanBeNull]
        public virtual string Fax { get; set; }
        
        [CanBeNull]
        public virtual string Notes { get; set; }



        public Organization()
        {

        }

        public Organization(Guid id, string name, string number, string street, string city, string state, string zipcode, string phone, string fax, string notes)
        {
           Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), OrganizationConsts.NameMaxLength, 0);
            Check.Length(number, nameof(number), OrganizationConsts.NumberMaxLength, 0);
            Check.Length(street, nameof(street), OrganizationConsts.StreetMaxLength, 0);
            Check.Length(city, nameof(city), OrganizationConsts.CityMaxLength, 0);
            Check.Length(state, nameof(state), OrganizationConsts.StateMaxLength, 0);
            Check.Length(zipcode, nameof(zipcode), OrganizationConsts.ZipcodeMaxLength, 0);
            Check.Length(phone, nameof(phone), OrganizationConsts.PhoneMaxLength, 0);
            Check.Length(fax, nameof(fax), OrganizationConsts.FaxMaxLength, 0);
            Check.Length(notes, nameof(notes), OrganizationConsts.NotesMaxLength, 0);
            Name = name;
            Number = number;
            Street = street;
            City = city;
            State = state;
            Zipcode = zipcode;
            Phone = phone;
            Fax = fax;
            Notes = notes;

        }
    }
}