using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.ViewModels
{
    public class ScheduleViewModel
    {
        public Guid CompanyId { get; set; }
        public List<string> notifications { get; set; }
    }
}
