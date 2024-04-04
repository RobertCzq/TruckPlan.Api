namespace TruckPlan.Api.Data.MockData;

public static class TruckPlanData
{
    public static IEnumerable<Models.TruckPlan> TruckPlans =
    [
        new Models.TruckPlan() { Id = 1, Name ="TestPlan1", DriverId = 1, StartDate = new DateTime(2022, 2, 1, 8, 10, 20), EndDate =new DateTime(2022, 2, 1, 12, 10, 20)},
        new Models.TruckPlan() { Id = 2, Name ="TestPlan2", DriverId = 2, StartDate = new DateTime(2022, 3, 1, 8, 10, 20), EndDate =new DateTime(2022, 3, 1, 12, 10, 20)},
        new Models.TruckPlan() { Id = 3, Name ="TestPlan3", DriverId = 1, StartDate = new DateTime(2018, 2, 1, 8, 10, 20), EndDate =new DateTime(2018, 2, 1, 12, 10, 20)},
        new Models.TruckPlan() { Id = 4, Name ="TestPlan4", DriverId = 1, StartDate = new DateTime(2018, 2, 2, 8, 10, 20), EndDate =new DateTime(2018, 2, 2, 12, 10, 20)},
    ];
}
