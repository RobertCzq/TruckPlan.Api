using TruckPlan.Api.Models;

namespace TruckPlan.Api.Data.MockData;

public static class DriverData
{
    public static IEnumerable<Driver> Drivers =
    [
        new Driver() { Id = 1, Name ="Driver1", BirthDate = new DateTime(1960, 2, 1), Address = "DummyAddress1", PhoneNumber = "+45 00000000"},
        new Driver() { Id = 2, Name ="Driver2", BirthDate = new DateTime(1978, 2, 1), Address = "DummyAddress2", PhoneNumber = "+45 00000001"},
    ];
}
