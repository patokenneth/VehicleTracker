using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VehicleTracker.DataContext;
using VehicleTracker.Models;
using VehicleTracker.ViewModels;

namespace VehicleTracker.Authentication.Service
{
    public class RegisterService
    {
        private readonly AppUserContext _context;

        public RegisterService()
        {

        }
        public async Task<int> CreatUser(RegisterUserViewModel registerModel, AppUserContext context)
        {
            var hmac = new HMACSHA512();

            ApplicationUser newUser = new ApplicationUser()
            {
                IsAdmin = registerModel.isAdmin,
                password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerModel.password)),
                Passwordsalt = hmac.Key
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser.Id;


        }

        public async Task<int> CreateVehicle()
        {
            Vehicle newVehicle = new Vehicle
            {
                RegistrationDate = DateTime.Now
            };

            _context.Vehicles.Add(newVehicle);
            await _context.SaveChangesAsync();

            return newVehicle.Id;
        }
    }
}
