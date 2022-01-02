using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        
    }
}
