using C_.Enum;

namespace C_.Models
{
    class ParkingSpot
    {
        public Guid SpotId { get; set; }
        public VehicleType SpotType { get; set; }
        public SpotStatus Status { get; set; } = SpotStatus.Available;
        public int LevelId { get; set; }
    }
}
