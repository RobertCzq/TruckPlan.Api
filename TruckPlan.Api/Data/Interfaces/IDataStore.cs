using TruckPlan.Api.Models;

namespace TruckPlan.Api.Data.Interfaces;

public interface IDataStore
{
    Task<IEnumerable<Models.TruckPlan>> GetAllPlans();
    Task<Driver?> GetDriverById(int driverId);
    Task<IEnumerable<GpsDataModel>> GetGpsCoordinatesForPlan(int planId);
}
