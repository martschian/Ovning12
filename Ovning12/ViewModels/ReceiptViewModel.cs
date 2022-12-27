using Microsoft.EntityFrameworkCore;
using Ovning12.Models;
using System.ComponentModel.DataAnnotations;

namespace Ovning12.ViewModels
{
    public class ReceiptViewModel
    {
        public int ParkedVehicleId { get; set; }
        
        [Display(Name = "Fordonstyp")]
        public VehicleTypes VehicleType { get; set; }
        [Display(Name = "Fordonstyp")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Märke och modell")]
        public string VehicleMakeAndModel { get; set; }
        [Display(Name = "Checkades in")]
        public DateTimeOffset ArrivalDateTime { get; set; }
        [Display(Name = "Checkades ut")]
        public DateTimeOffset CheckoutDateTime { get; set; }
        [Display(Name = "Tid i garaget")]
        public TimeSpan TimeParked => CheckoutDateTime - ArrivalDateTime;
        [Display(Name = "Kostnad")]
        public decimal Price { get; set; }
    }
}
