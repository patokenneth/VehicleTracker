using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class ApplicationUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Passwordsalt { get; set; }
        public byte[] password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
