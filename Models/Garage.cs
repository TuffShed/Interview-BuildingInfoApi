using BuildingInfoApi.Enums;

namespace BuildingInfoApi.Models
{
    public class Garage : BaseBuilding
    {
        public Garage()
            : base(BuildingType.Garage, false)
        {
        }
    }
}