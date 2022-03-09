using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class ServiceProviderService
    {
        public int ServiceRequestId { get; set; }
        public string ServiceStartDate { get; set; }
        public string startTime { get; set; }

        public string endTime { get; set; }
        public decimal TotalCost { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress1 { get; set; }

        public string CustomerAddress2 { get; set; }

        public int? timeConflict { get; set; }
        public string ServiceProvider { get; set; }

        public decimal SPRatings { get; set; }

        public int? Status { get; set; }
        public string SPAvatar { get; set; }

        public string Comments { get; set; }

        public bool AlreadyRated { get; set; }
    }
}
