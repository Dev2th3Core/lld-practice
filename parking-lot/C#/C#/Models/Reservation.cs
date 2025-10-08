using C_.Enum;

namespace C_.Models
{
    class Reservation
    {
        public Guid ReservationId { get; set; } = Guid.NewGuid();
        public required ParkingSpot Spot { get; set; }
        public required Vehicle Vehicle { get; set; }
        public SpotStatus Status { get; set; } = SpotStatus.Reserved;
    }
}
