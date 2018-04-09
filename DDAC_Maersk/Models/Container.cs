using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DDAC_Maersk.Models
{
    public class Container
    {
        [Key]
        public int ContainerID { get; set; }

        [Required]
        [Display(Name = "Type of Container")]
        public string TypeOfContainer { get; set; }

        [Required]
        [Display(Name = "Weight of Container")]
        public int WeightofContainer { get; set; } 

        public Order Order { get; set; }

        public int OrderID { get; set; }

    }
}