using TruckPlan.Api.Models;

namespace TruckPlan.Api.Services.Interfaces;

public interface ITruckPlanService
{
    Task<double> GetDistanceForTruckPlan(int planId);
    Task<string> GetCountry(double latitude, double longitude);
    Task<double> GetDistanceForDrivers(DistanceForDriversRequesModel distanceForDriversRequesModel);
}
