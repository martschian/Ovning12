using Microsoft.EntityFrameworkCore;
using Ovning12.Models;
using System.ComponentModel.DataAnnotations;

namespace Ovning12.ViewModels
{
    public class ReceiptViewModel
    {
        public int ParkedVehicleId { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public string RegistrationNumber { get; set; }
        public string VehicleMakeAndModel { get; set; }
        public DateTimeOffset ArrivalDateTime { get; set; }
        public DateTimeOffset CheckoutDateTime { get; set; }
        public TimeSpan TimeParked => CheckoutDateTime - ArrivalDateTime;
        public decimal Price => (decimal)Math.Floor(TimeParked.TotalHours) * 12 + 12;
    }
}
