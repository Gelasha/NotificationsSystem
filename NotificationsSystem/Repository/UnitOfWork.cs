using NotificationsSystem.Domain;
using NotificationsSystem.Domain.CompaniesAggregate;
using NotificationsSystem.Domain.SchedulsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NotificationDbContext _context;
        public ICompaniesRepository Companies { get; }

        public ISchedulesRepository Schedules { get; }
        public UnitOfWork(NotificationDbContext notificationDbConext,
            ICompaniesRepository companiesRepository,
            ISchedulesRepository schedulesRepository)
        {
            this._context = notificationDbConext;

            this.Companies = companiesRepository;
            this.Schedules = schedulesRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
