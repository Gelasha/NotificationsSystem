using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.DTOs
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        public string ConmpanyName { get; set; }
        public string ConmpanyNumber { get; set; }
        public string Market { get; set; }
        public string CompanyType { get; set; }
    }
}
