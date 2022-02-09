using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class scheduleService
    {
        public DateTime Date { get; set; }

        [Obsolete]
        public TimeZone time { get; set; }

        public int Duration { get; set; }

        public Extra extra { get; set; }

        public String Comments { get; set; }

        public bool havePet { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public bool rememberMe { get; set; }
    }
}
