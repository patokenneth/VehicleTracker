using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.Repository;
using VehicleTracker.ViewModels;

namespace VehicleTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly LocationRepository _locationRepo;

        public VehicleController(LocationRepository locationRepository)
        {
            _locationRepo = locationRepository;
        }

        [HttpPost]
        [Route("RecordPosition")]
        public async Task<IActionResult> UpdateLocation(RegisterPositionViewModel regModel)
        {
            bool updated = await _locationRepo.RecordPosition(regModel);

            if (updated)
            {
                return Ok(new { message = "Successfully updated."});
            }

            return BadRequest(new { message = "Failed to update vehicle location."});
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        [Route("GetCurrentLocation/{VehicleId}")]
        public async Task<IActionResult> RetrieveLocation(int VehicleId)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        {
            var position = await _locationRepo.GetCurrentPosition(VehicleId);
            return Ok(position);
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IEnumerable<GetVehiclePosition>> GetAllPosition([FromQuery] int vehicleID, DateTime? startTime, DateTime? endTime)
        {
            var locationHistory = await _locationRepo.GetAllPositions(vehicleID, startTime, endTime);

            return locationHistory;

        }
    }
}
