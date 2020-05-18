using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.HelpDesk.Organizations
{
    public interface IOrganizationRepository : IRepository<Organization, Guid>
    {
        Task<List<Organization>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}