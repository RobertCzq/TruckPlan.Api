namespace TruckPlan.Api.Models;

public class Driver
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}
