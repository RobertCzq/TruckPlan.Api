using TruckPlan.Api.ApiClient.Interfaces;
using TruckPlan.Api.Data.Interfaces;
using TruckPlan.Api.Services.Interfaces;

namespace TruckPlan.Api.Services
{
    public class TruckPlanService : ITruckPlanService
    {
        private readonly ILogger<TruckPlanService> _logger;
        private readonly IDataStore _dataStore;
        private readonly IDistanceCalculatorService _distanceCalculatorService;
        private readonly IAgeCalculatorService _ageCalculatorService;
        private readonly IGeonamesApiClient _geonamesApiClient;

        public TruckPlanService(ILogger<TruckPlanService> logger,
            IDataStore dataStore,
            IDistanceCalculatorService distanceCalculatorService,
            IAgeCalculatorService ageCalculatorService,
            IGeonamesApiClient geonamesApiClient)
        {
            _logger = logger;
            _dataStore = dataStore;
            _distanceCalculatorService = distanceCalculatorService;
            _ageCalculatorService = ageCalculatorService;
            _geonamesApiClient = geonamesApiClient;
        }

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

        public async Task<double> GetDistanceForDrivers()
        {
            var ageLimit = 50;
            var givenCountryName = "Germany";
            var startTime = new DateTime(2018, 2, 1, 0, 0, 0);
            var endTime = new DateTime(2018, 2, 28, 0, 0, 0);
            var plans = await _dataStore.GetAllPlans();

            if (plans == null || !plans.Any())
            {
                _logger.LogInformation("Could not calculate distance!");
                return double.MinValue;
            }


            var filteredPlans = plans.Where(plan => DateTime.Compare(startTime, plan.StartDate) <= 0
                                                    && DateTime.Compare(plan.EndDate, endTime) <= 0);
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
                    if (age > ageLimit)
                        filteredByDriver.Add(plan);
                }
            }

            if (!filteredByDriver.Any())
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
                    if (countryName.Equals(givenCountryName))
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
