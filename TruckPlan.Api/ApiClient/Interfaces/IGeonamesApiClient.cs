namespace TruckPlan.Api.ApiClient.Interfaces;

public interface IGeonamesApiClient
{
    Task<string?> GetCountryName(double latitude, double longitude);
}
