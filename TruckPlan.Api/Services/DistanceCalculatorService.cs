using Geolocation;
using TruckPlan.Api.Models;
using TruckPlan.Api.Services.Interfaces;

namespace TruckPlan.Api.Services;

public class DistanceCalculatorService : IDistanceCalculatorService
{
    public double CalculateDistance(IEnumerable<GpsDataModel> gpsDataSet)
    {
        if (gpsDataSet.Count() == 1)
        {
            return double.MinValue;
        }

        double distance = 0;
        var dataSet = gpsDataSet.ToArray();
        var first = dataSet[0];
        for (int i = 1; i < dataSet.Length; i++)
        {
            distance += GetDistanceBetweenTwoPoints(first, dataSet[i]);
            first = dataSet[i];
        }

        return distance;
    }

    private static double GetDistanceBetweenTwoPoints(GpsDataModel first, GpsDataModel second)
        => GeoCalculator.GetDistance(first.Latitude, first.Longitude, second.Latitude, second.Longitude, distanceUnit: DistanceUnit.Kilometers);

}

