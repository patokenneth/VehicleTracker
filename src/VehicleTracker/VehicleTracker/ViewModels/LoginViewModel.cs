using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20)]
        public string userName { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
    }
}
