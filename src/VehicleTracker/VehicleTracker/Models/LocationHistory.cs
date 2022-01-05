﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class LocationHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //The Id data type is bigint and not GUID since bigint is big enough to store the number of records we are expecting.
        //With a range of -9223372036854775808 to 9223372036854775807, it can continuously register locations of vehicles for thousands of years.
        //Additionally, integer has better indexing and disk efficiency that GUID.
        public Int64 Id { get; set; }
        public int VehicleID { get; set; }
        //I am assuming that the vehicle positions are sent using the "Geo URI" format; hence, a latitude and longitude
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Time { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}