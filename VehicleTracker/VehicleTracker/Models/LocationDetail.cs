using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class LocationDetail
    {
        [Key]
        public int Id { get; set; }
        public int VehicleID { get; set; }
        //I am assuming that the vehicle positions are sent using the "Geo URI" format; hence, a latitude and longitude
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Time => DateTime.Now;
        public Vehicle Vehicle { get; set; }
    }
}
