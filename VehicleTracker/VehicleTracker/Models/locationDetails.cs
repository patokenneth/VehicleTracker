using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class LocationDetails
    {
        [Key]
        public int VehicleID { get; set; }
        public string Position { get; set; }
        public string LocationName { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
