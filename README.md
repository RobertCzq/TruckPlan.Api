# TruckPlan.Api

The solution is structured in the following projects:
- TruckPlan.Api 
- TruckPlan.Api.Tests

The models from point 1 have been added to the models folder from the TruckPlan.Api project and they are called TruckPlan, Driver and GpsDataModel.
  
Points 2, 3 and 4 of the task have been implemented as the following api endpoints in the TruckPlanController:
- GetDistanceForTruckPlan/{planId} for point 2
- GetCountry/{latitude}/{longitude} for point 3
- GetDistanceForDrivers for point 4


Given the time constraints, I have decided to hardcode the data in memory and to only add a mock setup for testing without any actual tests.

Improvements:

- Data fetched from an actual data source.
- Add unit tests.
- Add integration tests.
