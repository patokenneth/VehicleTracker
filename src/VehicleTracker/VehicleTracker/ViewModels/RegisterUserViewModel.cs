using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.ViewModels
{
    public class RegisterUserViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }
    }
}
