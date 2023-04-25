using BuildingInfoApi.Enums;

namespace BuildingInfoApi.Models
{
    public class Shed : BaseBuilding
    {
        public Shed()
            : base(BuildingType.Shed, false)
        {
        }
    }
}