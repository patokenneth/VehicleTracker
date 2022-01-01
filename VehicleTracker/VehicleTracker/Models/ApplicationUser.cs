using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Passwordsalt { get; set; }
        public byte[] password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
