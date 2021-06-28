using NotificationsSystem.Domain.CompaniesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Repository
{
    public class CompaniesRepository : GenericRepository<Company>, ICompaniesRepository
    {
        public CompaniesRepository(NotificationDbContext context) : base(context)
        {

        }

        public IEnumerable<Company> GetCompaniesById(Guid id)
        {
            return _context.Companies.Where(s => s.Id == id);
        }
    }
}
