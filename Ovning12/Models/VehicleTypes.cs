using System.ComponentModel.DataAnnotations;

namespace Ovning12.Models
{
    public enum VehicleTypes
    {
        [Display(Name = "Bil")]
        Car,
        [Display(Name = "Buss")]
        Bus,
        [Display(Name = "Motorcykel")]
        Motorcyle,
        [Display(Name = "Båt")]
        Boat
    }
}
