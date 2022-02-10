using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Models
{
    public class scheduleService
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string time { get; set; }

        [Required]
        public int Duration { get; set; }

        public Extra extra { get; set; }

        public String Comments { get; set; }

        public bool havePet { get; set; }

        
    }
}
