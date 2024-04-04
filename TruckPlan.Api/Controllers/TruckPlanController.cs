using Microsoft.AspNetCore.Mvc;
using TruckPlan.Api.Models;
using TruckPlan.Api.Services.Interfaces;

namespace TruckPlan.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TruckPlanController(ITruckPlanService truckPlanService) : ControllerBase
{
    private readonly ITruckPlanService _truckPlanService = truckPlanService;

    [HttpGet("GetDistanceForTruckPlan/{planId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDistanceForTruckPlan(int planId)
    {
        var distance = await _truckPlanService.GetDistanceForTruckPlan(planId);

        if (distance > double.MinValue)
        {
            return Ok(distance);
        }

        return NotFound("Could not calculate distance");
    }


    [HttpGet("GetCountry/{latitude}/{longitude}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCountry(double latitude, double longitude)
    {
        var country = await _truckPlanService.GetCountry(latitude, longitude);

        if (!string.IsNullOrEmpty(country))
        {
            return Ok(country);
        }

        return NotFound();
    }

    [HttpGet("GetDistanceForDrivers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDistanceForDrivers([FromQuery] DistanceForDriversRequesModel distanceForDriversRequesModel)
    {
        var distance = await _truckPlanService.GetDistanceForDrivers(distanceForDriversRequesModel);

        if (distance > double.MinValue)
        {
            return Ok(distance);
        }

        return NotFound("Could not calculate distance");
    }
}