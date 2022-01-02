using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VehicleTracker.Models;

namespace VehicleTracker.DataContext
{
    public class AppUserContext : DbContext
    {
        public AppUserContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hmac = new HMACSHA512();

            var adminUser = new ApplicationUser
            {
                Id = 1,
                IsAdmin = true,
                password = hmac.ComputeHash(Encoding.UTF8.GetBytes("Sev7T")),
                Passwordsalt = hmac.Key,
                Username = "Seven"
            };

            builder.Entity<ApplicationUser>().HasData(adminUser);
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<LocationDetail> Location { get; set; }
    }
}
