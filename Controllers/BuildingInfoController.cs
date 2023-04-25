using BuildingInfoApi.Enums;
using BuildingInfoApi.Services.Definitions;
using Microsoft.AspNetCore.Mvc;

namespace BuildingInfoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BuildingInfoController : ControllerBase
{
    private readonly IBuildingService _buildingService;

    public BuildingInfoController(
        IBuildingService buildingService)
    {
        this._buildingService = buildingService;
    }

    [HttpGet("garages")]
    public IActionResult GetGarages()
    {
        var results = this._buildingService.ListByType((int)BuildingType.Garage);
        if (!results.Any())
        {
            return NotFound();
        }
        return Ok(results);

    }

    [HttpGet("type/{buildingTypeId}")]
    public IActionResult ListBuildingsByType(int buildingTypeId)
    {
        var buildings = this._buildingService.ListByType(buildingTypeId);

        return Ok(buildings);
    }


    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var building = this._buildingService.GetById(id);
        if (building == null)
        {
            return NotFound();
        }
        return Ok(building.DisplayBuildingData());
    }
    /// <summary>
    /// List houses from the building collection
    /// </summary>
    [HttpGet("houses")]
    public IActionResult GetHouses()
    {
        var results = this._buildingService.ListByType((int)BuildingType.House);
        if (!results.Any())
        {
            return NotFound();
        }
        return Ok(results);
    }

    /// <summary>
    /// List sheds from the building collection
    /// </summary>
    [HttpGet("sheds")]
    public IActionResult GetSheds()
    {
        var results = this._buildingService.ListByType((int)BuildingType.Shed);
        if (!results.Any())
        {
            return NotFound();
        }
        return Ok(results);
    }
}
