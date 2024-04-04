namespace TruckPlan.Api.Models;

public class TruckPlan
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int DriverId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
