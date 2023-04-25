using BuildingInfoApi.Models;

namespace BuildingInfoApi.Services.Definitions;

public interface IBuildingService
{
    /// <summary>
    /// The mock repository of buildings
    /// </summary>
    IList<IBuilding> BuildingCollection { get; set; }

    /// <summary>
    /// Retrieve a single building by id
    /// </summary>
    IBuilding? GetById(int id);

    /// <summary>
    /// Lists all buildings of a certain type
    /// </summary>
    IList<IBuilding> ListByType(int buildingTypeId);
}