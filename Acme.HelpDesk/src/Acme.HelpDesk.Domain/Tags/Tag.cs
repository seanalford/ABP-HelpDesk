using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Acme.HelpDesk.Tags
{
    public class Tag : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {

        
        public virtual Guid? TenantId { get; set; }
        
        [NotNull]
        public virtual string Name { get; set; }



        public Tag()
        {

        }

        public Tag(Guid id, string name)
        {
           Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), TagConsts.NameMaxLength, 0);
            Name = name;

        }
    }
}