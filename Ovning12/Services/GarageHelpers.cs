using Microsoft.EntityFrameworkCore;
using Ovning12.Data;
using Ovning12.Models;
using Ovning12.ViewModels;

namespace Ovning12.Services
{
    public class GarageHelpers : IGarageHelpers
    {
        private readonly Ovning12Context _context;

        public GarageHelpers(Ovning12Context context)
        {
            _context = context;
        }

        public async Task<StatisticsViewModel> GetCarageStatisticsAsync()
        {
            var vehicleTypeStats = new Dictionary<VehicleTypes, int>();
            var parkedVehicles = await _context.ParkedVehicle.ToListAsync();

            var vehicleGroups = parkedVehicles.GroupBy(x => x.VehicleType);

            //var vehicleGroups = await _context.ParkedVehicle.GroupBy(p => p.VehicleType).Select(p => new 
            //{
            //    Model = p.Key,
            //    Count = p.Count()
            //}).ToListAsync();

            foreach (var vehicleGroup in vehicleGroups)
            {
                vehicleTypeStats.Add(vehicleGroup.Key, vehicleGroup.Count());
            }
            
            var numberOfWheels = parkedVehicles.Select(pv => pv.NumberOfWheels).Sum();

            decimal totalOwed=0;
            DateTimeOffset currentTime = DateTimeOffset.Now;
            
            foreach (var item in parkedVehicles)
            {
                totalOwed += GetPriceForParkedDuration(item.ArrivalDateTime, currentTime);
            }

            return new StatisticsViewModel()
            {
                MoneyOwedStat = totalOwed,
                TotalNumberOfWheelsStat = numberOfWheels,
                VehicleTypesStat = vehicleTypeStats
            };
        }

        public decimal GetPriceForParkedDuration(DateTimeOffset start, DateTimeOffset end)
        {
            var duration = end - start;
            return (decimal)Math.Floor(duration.TotalHours) * 12 + 12;
        }
    }
}
