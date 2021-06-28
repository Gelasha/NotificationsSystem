using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Domain.SchedulsAggregate
{
    public interface ISchedulesRepository : IGenericRepository<Schedule>
    {
        IEnumerable<Schedule> GetScheduleById(Guid id);
    }
}
