using TruckPlan.Api.Data.Interfaces;
using TruckPlan.Api.Data.MockData;
using TruckPlan.Api.Models;

namespace TruckPlan.Api.Data
{
    public class DataStore : IDataStore
    {
        public Task<IEnumerable<Models.TruckPlan>> GetAllPlans()
        {
            return Task.FromResult(TruckPlanData.TruckPlans);
        }

        public Task<Driver?> GetDriverById(int driverId)
        {
            var driver = DriverData.Drivers.FirstOrDefault(dr => dr.Id == driverId);
            return Task.FromResult(driver);
        }

        public Task<IEnumerable<GpsDataModel>> GetGpsCoordinatesForPlan(int planId)
        {
            var coordinates = GpsData.GpsDataSet.Where(data => data.TruckPlanId == planId);
            return Task.FromResult(coordinates);
        }
    }
}
