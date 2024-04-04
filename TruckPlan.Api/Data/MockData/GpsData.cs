using TruckPlan.Api.Models;

namespace TruckPlan.Api.Data.MockData;

public static class GpsData
{
    public static IEnumerable<GpsDataModel> GpsDataSet =
    [
        new GpsDataModel() { Id = 1, Longitude = 8.794332, Latitude = 53.066988, TruckPlanId = 1, Date = new DateTime(2022, 2, 1, 8, 10, 20)},
        new GpsDataModel() { Id = 2, Longitude = 8.788140, Latitude = 53.062815, TruckPlanId = 1, Date = new DateTime(2022, 2, 1, 8, 15, 20)},
        new GpsDataModel() { Id = 3, Longitude = 8.799968, Latitude = 53.054912, TruckPlanId = 1, Date = new DateTime(2022, 2, 1, 8, 20, 20)},
        new GpsDataModel() { Id = 4, Longitude = 8.819326, Latitude = 53.048386, TruckPlanId = 1, Date = new DateTime(2022, 2, 1, 8, 25, 20)},
        new GpsDataModel() { Id = 5, Longitude = 8.794332, Latitude = 53.066988, TruckPlanId = 3, Date = new DateTime(2018, 2, 1, 8, 10, 20)},
        new GpsDataModel() { Id = 6, Longitude = 8.788140, Latitude = 53.062815, TruckPlanId = 3, Date = new DateTime(2018, 2, 1, 8, 15, 20)},
        new GpsDataModel() { Id = 7, Longitude = 8.799968, Latitude = 53.054912, TruckPlanId = 3, Date = new DateTime(2018, 2, 1, 8, 20, 20)},
        new GpsDataModel() { Id = 8, Longitude = 8.819326, Latitude = 53.048386, TruckPlanId = 3, Date = new DateTime(2018, 2, 1, 8, 25, 20)},
        new GpsDataModel() { Id = 9, Longitude = 8.794332, Latitude = 53.066988, TruckPlanId = 4, Date = new DateTime(2018, 2, 2, 8, 10, 20)},
        new GpsDataModel() { Id = 10, Longitude = 8.788140, Latitude = 53.062815, TruckPlanId = 4, Date = new DateTime(2018, 2, 2, 8, 15, 20)},
        new GpsDataModel() { Id = 11, Longitude = 8.799968, Latitude = 53.054912, TruckPlanId = 4, Date = new DateTime(2018, 2, 2, 8, 20, 20)},
        new GpsDataModel() { Id = 12, Longitude = 8.819326, Latitude = 53.048386, TruckPlanId = 4, Date = new DateTime(2018, 2, 2, 8, 25, 20)},
    ];
}
