using Ovning12.ViewModels;

namespace Ovning12.Services
{
    public interface IGarageHelpers
    {
        Task<StatisticsViewModel> GetCarageStatisticsAsync();
        decimal GetPriceForParkedDuration(DateTimeOffset start, DateTimeOffset end);
    }
}