using C_.Enum;

namespace C_.Models
{
    class Reservation
    {
        public Guid ReservationId { get; set; } = Guid.NewGuid();
        public Guid LotId { get; set; }
        public Guid LevelId { get; set; }
        public Guid SpotId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.ACTIVE;

        public override string ToString()
            => $"ReservationId: {ReservationId}, Spot: {SpotId}, Status: {Status}, Start: {StartTime}";
    }
}
