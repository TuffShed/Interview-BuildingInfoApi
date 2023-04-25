using BuildingInfoApi.Enums;

namespace BuildingInfoApi.Models;

public abstract class BaseBuilding : IBuilding
{
    public bool IsHabitable { get; }

    public BuildingType Type { get; }

    public int Height { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual string DisplayBuildingData()
    {
        var dataPoints = new string[]
        {
            $"Type: {this.Type}",
            $"Name: {this.Name}",
            $"Height: {this.Height} meters",
            $"Width: {this.Width} meters",
            $"Length: {this.Length} meters"
        };

        return string.Join(System.Environment.NewLine, dataPoints);
    }

    protected BaseBuilding(BuildingType buildingType, bool isHabitable)
    {
        var random = new Random(Guid.NewGuid().GetHashCode());

        this.Type = buildingType;
        this.IsHabitable = isHabitable;

        this.Height = random.Next(8, 20);
        this.Width = random.Next(15, 50);
        this.Length = random.Next(15, 50);
    }
}