using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maersk.Models
{
    public class Ship
    {
        [Key]
        public int ShipID { get; set; }

        [Required]
        [Display (Name = "Ship Name")]
        public string ShipName { get; set; }

        [Required]
        [Display(Name = "Ship Container Space")]
        public int ShipContainerSpace { get; set; }
    }
}