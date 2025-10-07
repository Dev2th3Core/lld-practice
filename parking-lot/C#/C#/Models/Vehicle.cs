using C_.Enum;

namespace C_.Models
{
    class Vehicle
    {
        public Guid VehicleId { get; set; }
        public VehicleType Type { get; set; }
        public string LicensePlate { get; set; }
    }
}
