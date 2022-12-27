using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ovning12.Models
{
    [Index(nameof(RegistrationNumber), IsUnique = true)]
    public class ParkedVehicle
    {
        public int ParkedVehicleId { get; set; }

        [Required]
        [Display(Name = "Fordonstyp")]
        public VehicleTypes VehicleType { get; set; }

        [Required]
        [Display(Name = "Märke")]
        [StringLength(20, MinimumLength = 3)]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Färg")]
        [StringLength(10, MinimumLength = 3)]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Antal hjul")]
        [Range(0,4)]
        public int NumberOfWheels { get; set; }

        [Required]
        [Display(Name = "Modellbeteckning")]
        [StringLength(20, MinimumLength = 3)]
        public string Model { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Registeringsnummer")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Checkades in")]
        public DateTimeOffset ArrivalDateTime { get; set; }
    }
}
