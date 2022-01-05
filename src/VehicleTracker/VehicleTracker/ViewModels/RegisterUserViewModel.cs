using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [StringLength(20)]
        public string username { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        [Required]
        public bool isAdmin { get; set; }
    }
}
