using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.ViewModels
{
    public class RegisterPositionViewModel
    {
        [Required]
        public int VehicleId { get; set; }
        [Required]
        //using double for precision
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }

    }
}
