using NotificationsSystem.Domain.CompaniesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Domain.SchedulsAggregate
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTime SendDate { get; set; }
    }
}
