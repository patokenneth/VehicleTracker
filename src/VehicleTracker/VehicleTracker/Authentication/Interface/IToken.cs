using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.Models;

namespace VehicleTracker.Authentication.Interface
{
    public interface IToken
    {
        string CreateToken(ApplicationUser user, bool isAdmin);
    }
}
