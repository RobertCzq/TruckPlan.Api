using TruckPlan.Api.ApiClient.Interfaces;
using TruckPlan.Api.Data.Interfaces;
using TruckPlan.Api.Models;
using TruckPlan.Api.Services.Interfaces;

namespace TruckPlan.Api.Services
{
    public class TruckPlanService(ILogger<TruckPlanService> logger,
        IDataStore dataStore,
        IDistanceCalculatorService distanceCalculatorService,
        IAgeCalculatorService ageCalculatorService,
        IGeonamesApiClient geonamesApiClient) : ITruckPlanService
    {
        private readonly ILogger<TruckPlanService> _logger = logger;
        private readonly IDataStore _dataStore = dataStore;
        private readonly IDistanceCalculatorService _distanceCalculatorService = distanceCalculatorService;
        private readonly IAgeCalculatorService _ageCalculatorService = ageCalculatorService;
        private readonly IGeonamesApiClient _geonamesApiClient = geonamesApiClient;

        public async Task<string> GetCountry(double latitude, double longitude)
        {
            var countryName = await _geonamesApiClient.GetCountryName(latitude, longitude);

            if (!string.IsNullOrEmpty(countryName))
            {
                return countryName;
            }

            _logger.LogInformation("Could not find country from given coordinates!");
            return string.Empty;
        }

        public async Task<double> GetDistanceForDrivers(DistanceForDriversRequesModel requestModel)
        {
            var plans = await _dataStore.GetAllPlans();
            var startDate = new DateTime(requestModel.Year, requestModel.Month, 1, 0, 0, 0);
            var endDate = new DateTime(requestModel.Year, requestModel.Month + 1, 1, 0, 0, 0);

            if (plans == null || !plans.Any())
            {
                _logger.LogInformation("Could not calculate distance!");
                return double.MinValue;
            }


            var filteredPlans = plans.Where(plan => DateTime.Compare(startDate, plan.StartDate) <= 0
                                                    && DateTime.Compare(plan.EndDate, endDate) <= 0);
            if (!filteredPlans.Any())
            {
                _logger.LogInformation("Could not calculate distance!");
                return double.MinValue;
            }

            var filteredByDriver = new List<Models.TruckPlan>();
            foreach (var plan in filteredPlans)
            {
                var driver = await _dataStore.GetDriverById(plan.DriverId);
                if (driver != null)
                {
                    var age = _ageCalculatorService.CalculateAge(driver.BirthDate);
                    if (age > requestModel.AgeLimit)
                    {
                        filteredByDriver.Add(plan);
                    }
                }
            }

            if (filteredByDriver.Count == 0)
            {
                _logger.LogInformation("Could not calculate distance!");
                return double.MinValue;
            }

            double distance = 0;
            foreach (var plan in filteredByDriver)
            {
                var coordinates = await _dataStore.GetGpsCoordinatesForPlan(plan.Id);
                if (coordinates != null && coordinates.Any())
                {
                    var countryName = await _geonamesApiClient.GetCountryName(coordinates.First().Latitude, coordinates.First().Longitude);
                    if (countryName.Equals(requestModel.CountryName, StringComparison.OrdinalIgnoreCase))
                    {
                        distance += _distanceCalculatorService.CalculateDistance(coordinates);
                    }
                }
            }

            if (distance > 0)
            {
                return distance;
            }

            _logger.LogInformation("Could not calculate distance!");
            return double.MinValue;
        }

        public async Task<double> GetDistanceForTruckPlan(int planId)
        {
            var gpsCoordinatesList = await _dataStore.GetGpsCoordinatesForPlan(planId);
            if (gpsCoordinatesList != null && gpsCoordinatesList.Any())
            {
                var distance = _distanceCalculatorService.CalculateDistance(gpsCoordinatesList);
                return distance;
            }

            _logger.LogInformation("Could not calculate distance because there was no gps data for the plan!");

            return double.MinValue;
        }
    }
}
