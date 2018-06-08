using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pos.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Display(Name = "Is Manufacturer")]
        public bool IsManufacturer { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(11)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Range(0, long.MaxValue)]
        [Display(Name = "Account Payable")]
        public long AccountPayable { get; set; }
    }
}