using C_.Enum;
using C_.Models;

namespace C_.Factory
{
    /// <summary>
    /// A concrete implementation of <see cref="IVehicleFactory"/> that creates specific vehicle types.
    /// </summary>
    class VehicleFactory : IVehicleFactory
    {
        /// <summary>
        /// Creates a new vehicle instance based on the specified type.
        /// </summary>
        /// <param name="vehicleType">The type of vehicle to create (e.g., CAR, BIKE).</param>
        /// <param name="licensePlate">The license plate of the new vehicle.</param>
        /// <returns>A new <see cref="Vehicle"/> instance (e.g., <see cref="Car"/>, <see cref="Bike"/>).</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid vehicle type is provided.</exception>
        public Vehicle CreateVehicle(VehicleType vehicleType, string licensePlate)
        {
            return vehicleType switch
            {
                VehicleType.CAR => new Car(licensePlate),
                VehicleType.BIKE => new Bike(licensePlate),
                VehicleType.VAN => new Van(licensePlate),
                _ => throw new ArgumentException($"Invalid vehicle type: {vehicleType}")
            };
        }
    }
}
