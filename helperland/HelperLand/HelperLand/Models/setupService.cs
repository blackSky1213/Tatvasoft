using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
   
    public class setupService
    {
        [Required]
        public string postalCode { get; set; }
    }
}
