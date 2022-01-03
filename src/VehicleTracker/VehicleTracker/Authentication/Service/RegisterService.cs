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

        public RegisterService(AppUserContext context)
        {
            _context = context;
        }

        public ApplicationUser CreatUser(RegisterUserViewModel registerModel)
        {
            var hmac = new HMACSHA512();

            ApplicationUser newUser = new ApplicationUser()
            {
                IsAdmin = registerModel.isAdmin,
                password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerModel.password)),
                Passwordsalt = hmac.Key,
                Username = registerModel.username
            };

            _context.Users.Add(newUser);
            _context.SaveChangesAsync();

            return newUser;


        }

        public bool UserExists(string username)
        {
            return _context.Users.Any(x => x.Username.ToLower() == username.ToLower());
        }


        public (bool, ApplicationUser) SignInUser(LoginViewModel loginModel)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == loginModel.userName);

            var hmac = new HMACSHA512(user.Passwordsalt);

            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginModel.password));

            for (int i = 0; i < hashedPassword.Length; i++)
            {
                if (hashedPassword[i] != user.password[i])
                {
                    return (false, null);
                }
            }

            return (user.IsAdmin ? true : false, user);
            
        }
    }
}
