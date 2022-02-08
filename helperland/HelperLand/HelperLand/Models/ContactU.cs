using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HelperLand.Models
{
    public partial class ContactU
    {
      
        public int ContactUsId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "invalid number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
        public string UploadFileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string FileName { get; set; }

        [NotMapped]
        public IFormFile AttechmentFile { get; set;  }
    }
}
