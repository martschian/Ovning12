using Microsoft.EntityFrameworkCore;

namespace Ovning12.Models
{
    public class ParkedVehicle
    {
        public int ParkedVehicleId { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string RegistrationNumber { get; set; }

        public DateTimeOffset ArrivalDateTime { get; set; }
        public ParkedVehicle()
        {
        }
    }
}
