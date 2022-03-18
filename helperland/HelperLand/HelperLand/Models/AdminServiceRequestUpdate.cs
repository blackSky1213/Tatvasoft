using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class AdminServiceRequestUpdate
    {
        public int ServiceRequestId { get; set; }

        public DateTime ServiceStartDate { get; set; }

        public DateTime StartTime { get; set; }

        public string StreetName { get; set; }

        public string HouseNumber { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Comment { get; set; }

        public bool IsTaken { get; set; }
    }
}
