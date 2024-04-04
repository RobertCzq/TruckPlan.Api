using System.ComponentModel.DataAnnotations;

namespace TruckPlan.Api.Models;

public class DistanceForDriversRequesModel
{
    [Required]
    public int AgeLimit { get; set; }
    [Required]
    public string CountryName { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    [Range(1, 12)]
    public int Month { get; set; }

}
