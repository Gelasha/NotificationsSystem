using NotificationsSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationsSystem.Validator
{
    public class CheckNotification
    {
        public static bool Enabled(string type, string[] companyTypes)
        {   
            if (companyTypes.Contains(type))
            {
                return true;
            }
           else
            {
                return false;
            }
        }
    }
}
