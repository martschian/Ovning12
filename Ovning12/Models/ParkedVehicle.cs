namespace Ovning12.Models
{
    public class ParkedVehicle
    {
        public int ParkedVehicleId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTimeOffset ArrivalDateTime { get; }

        public ParkedVehicle(string model, string make, VehicleType vehicleType, string registrationNumber)
        {
            ArrivalDateTime = DateTimeOffset.Now;
            Model = model;
            Make = make;
            VehicleType = vehicleType;
            RegistrationNumber = registrationNumber;
        }
    }
}
