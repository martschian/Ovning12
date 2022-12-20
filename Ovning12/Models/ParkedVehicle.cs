using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ovning12.Models
{
    public class ParkedVehicle
    {
        public int ParkedVehicleId { get; set; }

        [Required]
        [Display(Name = "Fordonstyp")]
        public VehicleTypes VehicleType { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Model { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Make { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Registeringsnummer")]
        public string RegistrationNumber { get; set; }

        public DateTimeOffset ArrivalDateTime { get; set; }
    }
}
