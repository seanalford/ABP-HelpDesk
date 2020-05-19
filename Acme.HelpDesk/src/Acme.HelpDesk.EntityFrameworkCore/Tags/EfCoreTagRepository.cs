using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Acme.HelpDesk.EntityFrameworkCore;

namespace Acme.HelpDesk.Tags
{
    public class EfCoreTagRepository : EfCoreRepository<HelpDeskDbContext, Tag, Guid>, ITagRepository
    {
        public EfCoreTagRepository(IDbContextProvider<HelpDeskDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Tag>> GetListAsync(
            string filterText = null,
            string name = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, name);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TagConsts.DefaultSorting : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, name);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Tag> ApplyFilter(
            IQueryable<Tag> query,
            string filterText,
            string name = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name));
        }
    }
}