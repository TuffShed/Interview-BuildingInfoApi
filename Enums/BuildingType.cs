using System.ComponentModel.DataAnnotations;

namespace BuildingInfoApi.Enums;

public enum BuildingType
{
    [Display(Name = "House")]
    House = 0,

    [Display(Name = "Shed")]
    Shed = 1,

    [Display(Name = "Garage")]
    Garage = 2
}