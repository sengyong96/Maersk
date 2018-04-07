using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maersk.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Customer Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Customer Contact No")]
        public string ContactNo { get; set; }


    }
}