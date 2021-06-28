using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotificationsSystem.Domain;
using NotificationsSystem.Domain.CompaniesAggregate;
using NotificationsSystem.Domain.SchedulsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<ICompaniesRepository, CompaniesRepository>();
            services.AddTransient<ISchedulesRepository, SchedulesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<NotificationDbContext>(opt => opt
                .UseSqlite("data source=NotificationDatabase.db;"));
            return services;
        }
    }
}
