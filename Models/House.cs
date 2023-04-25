using System.Text;
using BuildingInfoApi.Enums;

namespace BuildingInfoApi.Models;

public class House : BaseBuilding
{
    private IList<IBuilding> _propertyBuildings = new List<IBuilding>();

    /// <summary>
    /// Buildings on the property of the house
    /// </summary>
    public IList<IBuilding> PropertyBuildings
    {
        get
        {
            return this._propertyBuildings ??= new List<IBuilding>();
        }
    }

    public House()
        : base(BuildingType.House, true)
    { }

    public void AddNewBuilding(IBuilding newPropertyBuilding)
    {
        this._propertyBuildings.Add(newPropertyBuilding);
    }

    private IList<T> GetPropertyBuildingsOfType<T>(BuildingType filterType)
    {
        var retVal = this._propertyBuildings
            .Where(x => x.Type == filterType)
            .ToList();

        return retVal.ConvertAll(x => (T)x);
    }

    public IList<House> GetHouses()
    {
        return this.GetPropertyBuildingsOfType<House>(BuildingType.House);
    }

    public IList<Shed> GetSheds()
    {
        return this.GetPropertyBuildingsOfType<Shed>(BuildingType.Shed);
    }

    public override string DisplayBuildingData()
    {
        var baseData = new StringBuilder(base.DisplayBuildingData());

        if (this._propertyBuildings.Count > 0)
        {
            baseData.Append(System.Environment.NewLine).Append("** OWNED BUILDINGS **").Append(System.Environment.NewLine);
            foreach (var building in this._propertyBuildings)
            {
                baseData.Append("Building is owned by: ").AppendLine(this.Name);
                baseData.Append(building.DisplayBuildingData());
            }
        }

        return baseData.ToString();
    }
}