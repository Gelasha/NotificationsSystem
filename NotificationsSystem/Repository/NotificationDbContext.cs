using Microsoft.EntityFrameworkCore;
using NotificationsSystem.Domain.CompaniesAggregate;
using NotificationsSystem.Domain.SchedulsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Repository
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

    }
}
