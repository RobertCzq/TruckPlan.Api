namespace TruckPlan.Api.Models;

public class GpsDataModel
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int TruckPlanId { get; set; }
    public DateTime Date { get; set; }
}
