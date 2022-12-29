using Microsoft.AspNetCore.Mvc.RazorPages;
using Ovning12.Models;
using Ovning12.Services;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ovning12.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly IGarageHelpers _gh;

        [Display(Name = "Antal incheckade fordon per fordonstyp")]
        public Dictionary<VehicleTypes, int> VehicleTypesStat { get; set; }
        [Display(Name = "Total antal hjul")]
        public int TotalNumberOfWheelsStat { get; set; }
        [Display(Name = "Intäkt")]
        public decimal MoneyOwedStat { get; set; }

        public StatisticsModel(IGarageHelpers gh)
        {
            _gh = gh;
        }
        public async Task OnGetAsync()
        {
            var stats = await _gh.GetCarageStatisticsAsync();
            VehicleTypesStat = stats.VehicleTypesStat;
            TotalNumberOfWheelsStat= stats.TotalNumberOfWheelsStat;
            MoneyOwedStat= stats.MoneyOwedStat;
        }
    }
}
