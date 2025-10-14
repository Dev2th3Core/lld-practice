using C_.Enum;

namespace C_.Models
{
    /// <summary>
    /// Represents a vehicle that can be parked in the lot.
    /// </summary>
    class Vehicle
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        public Guid VehicleId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets the type of the vehicle (e.g., Car, Bike).
        /// </summary>
        public VehicleType Type { get; set; }
        /// <summary>
        /// Gets or sets the license plate number of the vehicle.
        /// </summary>
        public string LicensePlate { get; set; }
    }
}
