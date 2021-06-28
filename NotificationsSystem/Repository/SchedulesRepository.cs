using NotificationsSystem.Domain.CompaniesAggregate;
using NotificationsSystem.Domain.SchedulsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Repository
{
    public class SchedulesRepository : GenericRepository<Schedule>, ISchedulesRepository
    {
        public SchedulesRepository(NotificationDbContext context) : base(context)
        {

        }

        public IEnumerable<Schedule> GetScheduleById(Guid id)
        {
            return _context.Schedules.Where(s => s.Id == id);
        }
    }
}
