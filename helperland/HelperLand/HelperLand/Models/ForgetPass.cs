using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class ForgetPass
    {
        [Required]
        public string email { get; set; }
    }
}
