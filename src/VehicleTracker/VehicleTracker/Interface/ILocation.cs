using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.ViewModels;

namespace VehicleTracker.Interface
{
    public interface ILocation
    {
        Task<GetVehiclePosition> GetCurrentPosition(int VehicleID);
        Task<IEnumerable<GetVehiclePosition>> GetAllPositions(int VehicleID, DateTime? start, DateTime? end);
        Task<bool> RecordPosition(RegisterPositionViewModel locationModel);
    }
}
