using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DDAC_Maersk.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        

        [Required]
        [Display(Name ="Order Agent")]
        public string OrderAgent { get; set; }

        public Customer Customer { get; set; }

        public int CustomerID { get; set; }

        public Ship Ship { get; set; }

        public int ShipId { get; set; }

        public Schedule Schedule { get; set; }

        public int ScheduleID { get; set; }


    }
}
