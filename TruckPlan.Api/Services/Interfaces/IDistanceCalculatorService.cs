using TruckPlan.Api.Models;

namespace TruckPlan.Api.Services.Interfaces;

public interface IDistanceCalculatorService
{
    Double CalculateDistance(IEnumerable<GpsDataModel> gpsDataSet);
}
