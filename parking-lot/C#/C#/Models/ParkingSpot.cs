using C_.Enum;

namespace C_.Models
{
    class ParkingSpot
    {
        public Guid SpotId { get; set; } = Guid.NewGuid();
        public VehicleType SpotType { get; set; }
        public SpotStatus Status { get; set; } = SpotStatus.Available;
        public Guid LevelId { get; set; }
        public override string ToString()
        => $"SpotId: {SpotId}, Type: {SpotType}, Status: {Status}";
    }
}
