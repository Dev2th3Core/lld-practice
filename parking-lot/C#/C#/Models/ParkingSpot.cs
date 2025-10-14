using C_.Enum;

namespace C_.Models
{
    /// <summary>
    /// Represents a single parking spot within a parking level.
    /// </summary>
    class ParkingSpot
    {
        /// <summary>
        /// Gets or sets the unique identifier for the parking spot.
        /// </summary>
        public Guid SpotId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets the type of vehicle this spot can accommodate.
        /// </summary>
        public VehicleType SpotType { get; set; }
        /// <summary>
        /// Gets or sets the current status of the spot (e.g., Available, Reserved).
        /// </summary>
        public SpotStatus Status { get; set; } = SpotStatus.Available;
        /// <summary>
        /// Gets or sets the ID of the level this spot belongs to.
        /// </summary>
        public Guid LevelId { get; set; }
        /// <summary>
        /// Gets or sets the X-coordinate for spatial distance calculation.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the Y-coordinate for spatial distance calculation.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the Z-coordinate, representing the level or height.
        /// </summary>
        public double Z { get; set; } // Represents Level or Height
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        => $"SpotId: {SpotId}, Type: {SpotType}, Status: {Status}";
    }
}
