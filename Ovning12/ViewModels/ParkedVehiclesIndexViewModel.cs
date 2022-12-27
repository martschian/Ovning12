using Ovning12.Models;
using System.ComponentModel.DataAnnotations;

namespace Ovning12.ViewModels
{
    public class ParkedVehiclesIndexViewModel
    {
        public int ParkedVehicleId { get; set; }
        [Display(Name = "Fordonstyp")]
        public VehicleTypes VehicleType { get; set; }

        [Display(Name = "Registeringsnummer")] 
        public string RegistrationNumber { get; set; }
       
        [Display(Name = "Märke och modell")] 
        public string VehicleMakeAndModel { get; set; }
        
        [DataType(DataType.Time)]
        [Display(Name = "Tid i garaget")]
        [DisplayFormat(DataFormatString = @"{0:dd} days, {0:hh} hrs, and {0:mm} mins")]
        public TimeSpan TimeParked { get; set; }

    }
}
