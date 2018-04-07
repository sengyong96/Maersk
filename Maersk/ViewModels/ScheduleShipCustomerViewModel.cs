using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maersk.Models;

namespace Maersk.ViewModels
{
    public class ScheduleShipCustomerViewModel
    {
        public Ship Ship { get; set; }

        public int ShipID { get; set; }

        public List<Ship> Ships { get; set; }

        public Schedule Schedule { get; set; }

        public int ScheduleID { get; set; }

        public List<Schedule> Schedules { get; set; }

        public Customer Customer { get; set; }

        public List<Customer> Customers { get; set; }

        public Container Container { get; set; }

        public List<Container> Containers { get; set; }

        public Booking Booking { get; set; }   

        public List<Booking> Bookings { get; set; }
    }
}