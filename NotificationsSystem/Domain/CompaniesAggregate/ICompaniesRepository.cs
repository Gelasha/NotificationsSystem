using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Domain.CompaniesAggregate
{
    public interface ICompaniesRepository : IGenericRepository<Company>
    {
        IEnumerable<Company> GetCompaniesById(Guid id);
    }
}
