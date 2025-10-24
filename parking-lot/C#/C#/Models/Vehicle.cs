using C_.Enum;

namespace C_.Models
{
    /// <summary>
    /// Represents a vehicle that can be parked in the lot.
    /// </summary>
    public abstract class Vehicle
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// This constructor is protected to ensure that only derived classes can call it.
        /// </summary>
        /// <param name="type">The type of the vehicle.</param>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        protected Vehicle(VehicleType type, string licensePlate)
        {
            Type = type;
            LicensePlate = licensePlate;
        }
    }
    /// <summary>
    /// Represents a Car, which is a specific type of <see cref="Vehicle"/>.
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class with a specific license plate.
        /// </summary>
        /// <param name="licensePlate">The license plate of the car.</param>
        public Car(string licensePlate) : base(VehicleType.CAR, licensePlate) { }
    }
    /// <summary>
    /// Represents a Bike, which is a specific type of <see cref="Vehicle"/>.
    /// </summary>
    public class Bike : Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bike"/> class with a specific license plate.
        /// </summary>
        /// <param name="licensePlate">The license plate of the bike.</param>
        public Bike(string licensePlate) : base(VehicleType.BIKE, licensePlate) { }
    }
    /// <summary>
    /// Represents a Van, which is a specific type of <see cref="Vehicle"/>.
    /// </summary>
    public class Van : Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Van"/> class with a specific license plate.
        /// </summary>
        /// <param name="licensePlate">The license plate of the van.</param>
        public Van(string licensePlate) : base(VehicleType.VAN, licensePlate) { }
    }
}
