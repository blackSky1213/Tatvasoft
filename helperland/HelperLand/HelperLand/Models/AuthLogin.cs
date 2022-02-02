using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class AuthLogin
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public bool remember { get; set; }
    }
}
