using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class LocationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Let the data type of Id be int since a GUID or string will affect the DB size as the records grow
        public int Id { get; set; }
        public int VehicleID { get; set; }
        //I am assuming that the vehicle positions are sent using the "Geo URI" format; hence, a latitude and longitude
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Time { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
