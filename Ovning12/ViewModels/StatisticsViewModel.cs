using Ovning12.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ovning12.ViewModels
{
    public class StatisticsViewModel
    {
        [Display(Name = "Antal incheckade fordon per fordonstyp")]
        public Dictionary<VehicleTypes, int> VehicleTypesStat { get; set; }
        [Display(Name = "Total antal hjul")]
        public int TotalNumberOfWheelsStat { get; set; }
        [Display(Name = "Intäkt")]
        public decimal MoneyOwedStat { get; set; }
    }
}
