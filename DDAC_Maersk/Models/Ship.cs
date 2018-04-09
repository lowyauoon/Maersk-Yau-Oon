using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DDAC_Maersk.Models
{
    public class Ship
    {
        [Key]
        public int ShipId { get; set; }

        [Required]
        public string ShipName { get; set; }

        [Required]
        public int ShipContainerNumber { get; set; }

    }
}