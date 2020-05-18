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

namespace Acme.HelpDesk.Organizations
{
    public class EfCoreOrganizationRepository : EfCoreRepository<HelpDeskDbContext, Organization, Guid>, IOrganizationRepository
    {
        public EfCoreOrganizationRepository(IDbContextProvider<HelpDeskDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Organization>> GetListAsync(
            string filterText = null,
            string name = null,
            string number = null,
            string street = null,
            string city = null,
            string state = null,
            string zipcode = null,
            string phone = null,
            string fax = null,
            string notes = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, name, number, street, city, state, zipcode, phone, fax, notes);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? OrganizationConsts.DefaultSorting : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string number = null,
            string street = null,
            string city = null,
            string state = null,
            string zipcode = null,
            string phone = null,
            string fax = null,
            string notes = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, name, number, street, city, state, zipcode, phone, fax, notes);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Organization> ApplyFilter(
            IQueryable<Organization> query,
            string filterText,
            string name = null,
            string number = null,
            string street = null,
            string city = null,
            string state = null,
            string zipcode = null,
            string phone = null,
            string fax = null,
            string notes = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.Number.Contains(filterText) || e.Street.Contains(filterText) || e.City.Contains(filterText) || e.State.Contains(filterText) || e.Zipcode.Contains(filterText) || e.Phone.Contains(filterText) || e.Fax.Contains(filterText) || e.Notes.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(number), e => e.Number.Contains(number))
                    .WhereIf(!string.IsNullOrWhiteSpace(street), e => e.Street.Contains(street))
                    .WhereIf(!string.IsNullOrWhiteSpace(city), e => e.City.Contains(city))
                    .WhereIf(!string.IsNullOrWhiteSpace(state), e => e.State.Contains(state))
                    .WhereIf(!string.IsNullOrWhiteSpace(zipcode), e => e.Zipcode.Contains(zipcode))
                    .WhereIf(!string.IsNullOrWhiteSpace(phone), e => e.Phone.Contains(phone))
                    .WhereIf(!string.IsNullOrWhiteSpace(fax), e => e.Fax.Contains(fax))
                    .WhereIf(!string.IsNullOrWhiteSpace(notes), e => e.Notes.Contains(notes));
        }
    }
}