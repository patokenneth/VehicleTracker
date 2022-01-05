using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.Authentication.Service;
using VehicleTracker.DataContext;
using VehicleTracker.Interface;
using VehicleTracker.Models;
using VehicleTracker.Utility;
using VehicleTracker.ViewModels;

namespace VehicleTracker.Repository
{
    public class LocationRepository : ILocation
    {
        private readonly AppUserContext _context;
        private readonly RegisterService _service;
        private readonly ILogger<LocationRepository> _logger;
        public readonly IConfiguration _config;

        public LocationRepository(AppUserContext context, RegisterService service, ILogger<LocationRepository> logger, IConfiguration config)
        {
            _service = service; 
            _context = context;
            _config = config;
            _logger = logger;
        }

        public string key => _config["api_key"];

        public async Task<IEnumerable<GetVehiclePosition>> GetAllPositions(int VehicleID, DateTime? start, DateTime? end)
        {
             IEnumerable<GetVehiclePosition> locationDetails = null;

            if (_context.Location.Any(x => x.Id == VehicleID))
            {
                if (start == null || end == null)
                {
                    //If user does not provide a timeframe, start and end times are defined below
                    start ??= DateTime.Now.AddMinutes(-10);
                    end ??= DateTime.Now;
                }

                //Call IQueryable on context for a more efficient database query
                //Call "AsNoTracking" for GET queries since we do not need to track the context
                IQueryable<GetVehiclePosition> output = _context.Location.Where(v => v.VehicleID == VehicleID && v.Time >= start && v.Time <= end)
                                                         .OrderBy(o => o.Time).AsNoTracking()
                                                         .Select(vc => new GetVehiclePosition { Latitude = vc.Latitude, Longitude = vc.Longitude, 
                                                         LocationName = FetchName.ReturnName(key, vc.Latitude, vc.Longitude), Time = vc.Time });

                locationDetails = await output.ToListAsync();
            }

            return locationDetails;
        }



        public async Task<GetVehiclePosition> GetCurrentPosition(int VehicleID)
        {
            GetVehiclePosition locationDeets = null;

            //check that a vehicle with the given Id exists before trying to fetch the current position.
            if (_context.Vehicles.Any(x => x.Id == VehicleID))
            {
                //Call "AsNoTracking" for GET queries since we do not need to track the context
                IQueryable<GetVehiclePosition> position = _context.Location.Where(v => v.VehicleID == VehicleID).OrderBy(o => o.Time).AsNoTracking()
                                                         .Select(vc => new GetVehiclePosition { Latitude = vc.Latitude, Longitude = vc.Longitude, 
                                                         LocationName = FetchName.ReturnName(key, vc.Latitude, vc.Longitude), Time = vc.Time });

                return await position.LastOrDefaultAsync();
                                                     
            }

            _logger.LogInformation($"No vehicle with id {VehicleID}");

            return locationDeets;
        }



        public async Task<bool> RecordPosition(RegisterPositionViewModel locationModel)
        {
            /*In recording the position of a vehicle, we can opt to update an in-memory store to hold the latest position
             * and then write to a database for location history. However, that will amount to two write operations per record. 
             * Not to mention the memory implication of holding thousands of records. Since I do not think the admin will always need
             *  to fetch the instantaneous location of a vehicle, I had to forgo the option of an in-memory data store.
            */

            //put the process in a transaction to maintain database integrity.
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                //check that the vehicle is registered. Register it if false.
                if (!_context.Vehicles.Any(v => v.Id == locationModel.VehicleId))
                {
                    
                    Vehicle newVehicle = new Vehicle
                    {
                        Id = locationModel.VehicleId,
                        RegistrationDate = DateTime.Now
                    };

                    _context.Vehicles.Add(newVehicle);
                    await _context.SaveChangesAsync();
                }

                await transaction.CreateSavepointAsync("VehicleCreated");

              
                var position = new LocationHistory
                {
                    Latitude = locationModel.Latitude,
                    Longitude = locationModel.Longitude,
                    VehicleID = locationModel.VehicleId,
                    Time = DateTime.Now
                };

                _context.Location.Add(position);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log exception
                _logger.LogError($"failed to update record. Error message is {ex.Message}.");
                transaction.Rollback();
                return false;

            }

        }

        
    }
}
