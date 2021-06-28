using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Domain.CompaniesAggregate
{
    public class Company
    {
        public Guid Id { get; set; }
        public string ConmpanyName { get; set; }
        public string ConmpanyNumber { get; set; }
        public int Market { get; set; }
        public int CompanyType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
