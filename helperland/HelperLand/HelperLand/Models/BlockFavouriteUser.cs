using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class BlockFavouriteUser
    {

        public int UserIdFrom { get; set; }

        public int UserIdTo { get; set; }

        public string CustomerName { get; set; }

        public string ServiceProviderName { get; set; }

        public bool IsBlock { get; set; }

        public bool IsFavourite { get; set; }

        public decimal SPRatings { get; set; }

        public int ServiceProviderCleaning { get; set; }
    }
}
