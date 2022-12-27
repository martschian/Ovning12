using Ovning12.Models;

namespace Ovning12.ViewModels
{
    public class StatisticsViewModel
    {
        public Dictionary<VehicleTypes, int> VehicleTypesStat { get; set; }
        public int TotalNumberOfWheelsStat { get; set; }
        public decimal MoneyOwedStat { get; set; }
    }
}
