using C_.Enum;

namespace C_.Models
{
    class ParkingSpot
    {
        public Guid SpotId { get; set; } = Guid.NewGuid();
        public VehicleType SpotType { get; set; }
        public SpotStatus Status { get; set; } = SpotStatus.Available;
        public Guid LevelId { get; set; }
        // 3D coordinates for spatial distance calculation
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; } // Represents Level or Height
        public override string ToString()
        => $"SpotId: {SpotId}, Type: {SpotType}, Status: {Status}";
    }
}
