using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.ViewModels
{
    public class RegisterPositionViewModel
    {
        public int VehicleId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
