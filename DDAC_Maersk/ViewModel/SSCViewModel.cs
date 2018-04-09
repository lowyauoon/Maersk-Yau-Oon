using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDAC_Maersk.Models;

namespace DDAC_Maersk.ViewModel
{
    public class SSCViewModel
    {
        public Ship Ship { get; set; }

        public List<Ship> Ships { get; set; }

        public Schedule Schedule { get; set; }

        public List<Schedule> Schedules { get; set; }

        public Customer Customer { get; set; }

        public List<Customer> Customers { get; set; }

        public Container Container { get; set; }

        public List<Container> Containers { get; set; }

        public Order Order { get; set; }

        public List<Order> Orders { get; set; }
    }
}