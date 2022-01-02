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
        //Let the data type of Id be int since a GUID or string will affect the DB size as the records grow
        public int Id { get; set; }
        public int VehicleID { get; set; }
        //I am assuming that the vehicle positions are sent using the "Geo URI" format; hence, a latitude and longitude
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Time => DateTime.Now;
        public Vehicle Vehicle { get; set; }
    }
}
