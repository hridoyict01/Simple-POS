using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pos.Dtos
{
    public class SupplierDto
    {
         public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        public bool IsManufacturer { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(11)]
        
        public string PhoneNumber { get; set; }

        [Range(0, long.MaxValue)]
        public long AccountPayable { get; set; }
    }
}