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
        }
    }
}