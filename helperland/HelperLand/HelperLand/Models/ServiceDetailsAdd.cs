using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class ServiceDetailsAdd
    {
        public DateTime startDate { get; set; }
        public string startTime { get; set; }
        public int duration { get; set; }

        public string comment { get; set; }

        public bool havePet
        {
            get; set;
        }
        public int AddressId
        {
            get; set;
        }

        public int? ServiceProviderId { get; set; }
        public string postalCode { get; set; }

        public float extraHours { get; set; }

        public bool cabinet { get; set; }

        public bool fridge { get; set; }

        public bool oven { get; set; }

        public bool lundary { get; set; }

        public bool windows { get; set; }
    }
}
