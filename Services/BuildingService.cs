using BuildingInfoApi.Enums;
using BuildingInfoApi.Models;
using BuildingInfoApi.Services.Definitions;
using System.Linq;

namespace BuildingInfoApi.Services;

public class BuildingService : IBuildingService
{
    public IList<IBuilding> BuildingCollection { get; set; } = new List<IBuilding>();
    private readonly Random _random;
    private readonly Array _availableBuildingTypes = Enum.GetValues(typeof(BuildingType));

    public BuildingService()
    {
        this._random = new Random(Guid.NewGuid().GetHashCode());
        for (var i = 0; i < 10; i++)
        {
            this.BuildingCollection.Add(this.GenerateBuilding(i));
        }
    }

    private T CreateNewBuilding<T>(string name)
        where T: IBuilding
    {
        var retVal = Activator.CreateInstance<T>();
        retVal.Name = name;
        retVal.Id = this.BuildingCollection.Count + 1;

        return retVal;
    }

    private House BuildHouseWithChildBuildings(string name)
    {
        var weightedBuildingCount = new int[] {0, 0, 0, 1, 1, 2};
        var numberOfChildBuildings = weightedBuildingCount[this._random.Next(0, weightedBuildingCount.Length)];

        var masterHouse = this.CreateNewBuilding<House>(name);

        for (var i = 0; i < numberOfChildBuildings; i++)
        {
            masterHouse.AddNewBuilding(this.GenerateBuilding(i, masterHouse));
        }

        return masterHouse;
    }

    private IBuilding GenerateBuilding(int index, IBuilding? parentBuilding = null)
    {
        var buildingNamePrefix = parentBuilding != null ? $"{parentBuilding.Name}_" : string.Empty;
        var isChildBuilding = !string.IsNullOrEmpty(buildingNamePrefix);

        switch ((BuildingType)this._random.Next(0, this._availableBuildingTypes.Length))
        {
            case BuildingType.House:
                var houseName = $"{buildingNamePrefix}House_{index}";
                return !isChildBuilding ? this.BuildHouseWithChildBuildings(houseName) : this.CreateNewBuilding<House>(houseName);
            case BuildingType.Shed:
                return this.CreateNewBuilding<Shed>($"{buildingNamePrefix}Shed_{index}");
            case BuildingType.Garage:
                return this.CreateNewBuilding<Garage>($"{buildingNamePrefix}Garage_{index}");
            default:
                throw new NotImplementedException();
        }
    }

    public IList<IBuilding> ListByType(int buildingTypeId)
    {
        try
        {
            var buildingType = (BuildingType)buildingTypeId;
            return this.BuildingCollection.Where(x => x.Type == buildingType).ToList();
        }
        catch
        {
            return new List<IBuilding>();
        }
    }

    public IBuilding? GetById(int id)
    {
        return this.BuildingCollection.SingleOrDefault(x => x.Id == id);
    }
}