using Microsoft.AspNetCore.Mvc;
using TruckPlan.Api.Services.Interfaces;

namespace TruckPlan.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TruckPlanController : ControllerBase
{
    private readonly ITruckPlanService _truckPlanService;

    public TruckPlanController(ITruckPlanService truckPlanService)
    {
        _truckPlanService = truckPlanService;
    }

    [HttpGet("GetDistanceForTruckPlan/{planId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDistanceForTruckPlan(int planId)
    {
        var distance = await _truckPlanService.GetDistanceForTruckPlan(planId);
        return Ok(distance);
    }


    [HttpGet("GetCountry/{latitude}/{longitude}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCountry(double latitude, double longitude)
    {
        var country = await _truckPlanService.GetCountry(latitude, longitude);
        return Ok(country);
    }

    [HttpGet("GetDistanceForDrivers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDistanceForDrivers()
    {
        var distance = await _truckPlanService.GetDistanceForDrivers();
        return Ok(distance);
    }
}