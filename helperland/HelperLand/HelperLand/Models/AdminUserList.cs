using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class AdminUserList
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string UserType { get; set; }
      
        public string? PostalCode { get; set; }

        public string? City { get; set; }

        public string Mobile { get; set; }

        public string Date { get; set; }

        public bool UserStatus { get; set; }
    }
}
