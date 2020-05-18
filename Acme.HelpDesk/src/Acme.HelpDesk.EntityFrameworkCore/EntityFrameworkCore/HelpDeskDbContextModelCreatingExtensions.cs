using Volo.Abp.EntityFrameworkCore.Modeling;
using Acme.HelpDesk.Organizations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Acme.HelpDesk.EntityFrameworkCore
{
    public static class HelpDeskDbContextModelCreatingExtensions
    {
        public static void ConfigureHelpDesk(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(HelpDeskConsts.DbTablePrefix + "YourEntities", HelpDeskConsts.DbSchema);

            //    //...
            //});

            builder.Entity<Organization>(b =>
            {
                b.ToTable(HelpDeskConsts.DbTablePrefix + "Organizations", HelpDeskConsts.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.TenantId).HasColumnName(nameof(Organization.TenantId));
                b.Property(x => x.Name).HasColumnName(nameof(Organization.Name)).IsRequired().HasMaxLength(OrganizationConsts.NameMaxLength);
                b.Property(x => x.Number).HasColumnName(nameof(Organization.Number)).HasMaxLength(OrganizationConsts.NumberMaxLength);
                b.Property(x => x.Street).HasColumnName(nameof(Organization.Street)).HasMaxLength(OrganizationConsts.StreetMaxLength);
                b.Property(x => x.City).HasColumnName(nameof(Organization.City)).HasMaxLength(OrganizationConsts.CityMaxLength);
                b.Property(x => x.State).HasColumnName(nameof(Organization.State)).HasMaxLength(OrganizationConsts.StateMaxLength);
                b.Property(x => x.Zipcode).HasColumnName(nameof(Organization.Zipcode)).HasMaxLength(OrganizationConsts.ZipcodeMaxLength);
                b.Property(x => x.Phone).HasColumnName(nameof(Organization.Phone)).HasMaxLength(OrganizationConsts.PhoneMaxLength);
                b.Property(x => x.Fax).HasColumnName(nameof(Organization.Fax)).HasMaxLength(OrganizationConsts.FaxMaxLength);
                b.Property(x => x.Notes).HasColumnName(nameof(Organization.Notes)).HasMaxLength(OrganizationConsts.NotesMaxLength);

            });
        }
    }
}