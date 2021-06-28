using NotificationsSystem.Domain.CompaniesAggregate;
using NotificationsSystem.Domain.SchedulsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICompaniesRepository Companies { get; }
        ISchedulesRepository Schedules { get; }
        int Complete();
    }
}

