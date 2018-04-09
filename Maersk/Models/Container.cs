using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maersk.Models
{
    public class Container
    {
        [Key]
        public int ContainerID { get; set; }

        [Required]
        [Display(Name = "Type of Container")]
        public string ContainerType { get; set; }

        [Required]
        [Display(Name = "Space of the Container")]
        public double ContainerWeight { get; set; }

        public Booking Booking { get; set; }

        public int BookingID { get; set; }
    }
}