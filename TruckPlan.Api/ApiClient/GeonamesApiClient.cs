using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Globalization;
using TruckPlan.Api.ApiClient.Interfaces;
using TruckPlan.Api.Models;

namespace TruckPlan.Api.ApiClient;

public class GeonamesApiClient : IGeonamesApiClient
{
    private const string _getApiEndpoint = "/countryCodeJSON";
    private readonly HttpClient _httpClient;
    private readonly ILogger<GeonamesApiClient> _logger;

    public GeonamesApiClient(HttpClient httpClient, ILogger<GeonamesApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<string?> GetCountryName(double latitude, double longitude)
    {
        try
        {
            var query = new Dictionary<string, string>()
            {
                ["lat"] = latitude.ToString(new CultureInfo("en-US")),
                ["lng"] = longitude.ToString(new CultureInfo("en-US")),
                ["username"] = "rczq"
            };

            var apiAddress = string.Concat(_httpClient.BaseAddress, _getApiEndpoint);
            var uri = QueryHelpers.AddQueryString(apiAddress, query);
            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var countryDataString = await response.Content.ReadAsStringAsync();
                var countryData = JsonConvert.DeserializeObject<Country>(countryDataString);
                if (countryData != null)
                    return countryData?.CountryName;
            }

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not retrieve data from api.");
        }

        return String.Empty;
    }
}
