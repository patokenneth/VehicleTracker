using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.Interface;
using VehicleTracker.Repository;
using VehicleTracker.ViewModels;

namespace VehicleTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ILocation _locationRepo;

        public VehicleController(ILocation locationRepository)
        {
            _locationRepo = locationRepository;
        }

        [HttpPost]
        [Route("Locations/Updateposition")]
        public async Task<IActionResult> UpdateLocation(RegisterPositionViewModel regModel)
        {
            if (ModelState.IsValid)
            {
                bool updated = await _locationRepo.RecordPosition(regModel);

                if (updated)
                {
                    return Ok(new { message = "Successfully updated." });
                }

                return BadRequest(new { message = "Failed to update vehicle location." });
            }

            return UnprocessableEntity("Model validation failed. Kindly fill all the required fields.");
            
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        [Route("CurrentLocation/{VehicleId}")]
        public async Task<IActionResult> RetrieveLocation(int VehicleId)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        {
            var position = await _locationRepo.GetCurrentPosition(VehicleId);
            return Ok(position);
        }

        [HttpGet]
        [Produces("application/json")]
        [Authorize(Policy = "Admin")]
        [Route("LocationHistory")]
        public async Task<IEnumerable<GetVehiclePosition>> GetAllPosition([FromQuery] int vehicleID, DateTime? startTime, DateTime? endTime)
        {
            //Since this will potentially fetch a lot of records, it will be a good time 
            //for the client to include brotli or gzip compression in the headers since I have enabled compression in Startup.cs
            var locationHistory = await _locationRepo.GetAllPositions(vehicleID, startTime, endTime);

            return locationHistory;

        }
    }
}
