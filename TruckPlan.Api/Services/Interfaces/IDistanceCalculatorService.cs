using TruckPlan.Api.Models;

namespace TruckPlan.Api.Services.Interfaces;

public interface IDistanceCalculatorService
{
    double CalculateDistance(IEnumerable<GpsDataModel> gpsDataSet);
}
