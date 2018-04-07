using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maersk.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        [Display(Name = "Agent of Booking")]
        public string BookingAgent { get; set; }

        public Customer Customer { get; set; }

        public int CustomerID { get; set; }

        public Ship Ship { get; set; }

        public int ShipID { get; set; }

        public Schedule Schedule { get; set; }

        public int ScheduleID { get; set; }
    }
}