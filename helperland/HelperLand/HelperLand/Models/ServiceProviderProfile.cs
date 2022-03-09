using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class ServiceProviderProfile
    {
        public User user { get; set; }
        public UserAddress userAddress { get; set; }
    }
}
