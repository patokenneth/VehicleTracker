using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //since we have about 10,000 vehicles, an int data type is enough for our primary key.
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        
    }
}
