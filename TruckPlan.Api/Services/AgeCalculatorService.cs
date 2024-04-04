using TruckPlan.Api.Services.Interfaces;

namespace TruckPlan.Api.Services;

public class AgeCalculatorService : IAgeCalculatorService
{
    public int CalculateAge(DateTime dateOfBirth)
    {
        var age = DateTime.Now.Year - dateOfBirth.Year;

        if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
        {
            age--;
        }

        return age;
    }
}
