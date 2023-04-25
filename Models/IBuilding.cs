using BuildingInfoApi.Enums;

namespace BuildingInfoApi.Models;

public interface IBuilding
{
    /// <summary>
    /// Unique id of the building
    /// </summary>
    int Id { get; set; }

    /// <summary>
    /// Building model name
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// The building type
    /// </summary>
    BuildingType Type { get; }

    /// <summary>
    /// indicates if the building is habitable
    /// </summary>
    bool IsHabitable { get; }

    /// <summary>
    /// Building Height (meters)
    /// </summary>
    int Height { get; set; }

    /// <summary>
    /// Building Length (meters)
    /// </summary>
    int Length { get; set; }

    /// <summary>
    /// Building Width (meters)
    /// </summary>
    int Width { get; set; }

    /// <summary>
    /// Returns relevant data about the
    /// building
    /// </summary>
    string DisplayBuildingData();
}