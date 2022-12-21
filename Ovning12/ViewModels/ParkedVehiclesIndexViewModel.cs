using Ovning12.Models;
using System.ComponentModel.DataAnnotations;

namespace Ovning12.ViewModels
{
    public class ParkedVehiclesIndexViewModel
    {
        public int ParkedVehicleId { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public string RegistrationNumber { get; set; }
        public string VehicleMakeAndModel { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:dd} days, {0:hh} hrs, and {0:mm} mins")]
        public TimeSpan TimeParked { get; set; }

    }
}
