using C_.Enum;

namespace C_.Models
{
    /// <summary>
    /// Represents a reservation for a parking spot.
    /// </summary>
    class Reservation
    {
        /// <summary>
        /// Gets or sets the unique identifier for the reservation.
        /// </summary>
        public Guid ReservationId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets the ID of the parking lot where the spot is reserved.
        /// </summary>
        public Guid LotId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the parking level where the spot is located.
        /// </summary>
        public Guid LevelId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the reserved parking spot.
        /// </summary>
        public Guid SpotId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the vehicle for which the reservation is made.
        /// </summary>
        public Guid VehicleId { get; set; }
        /// <summary>
        /// Gets or sets the time the reservation started.
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets the time the reservation ended. Null if still active.
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Gets or sets the current status of the reservation (e.g., Active, Completed).
        /// </summary>
        public ReservationStatus Status { get; set; } = ReservationStatus.ACTIVE;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
            => $"ReservationId: {ReservationId}, Spot: {SpotId}, Status: {Status}, Start: {StartTime}";
    }
}
