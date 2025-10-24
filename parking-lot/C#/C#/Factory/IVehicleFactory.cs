using C_.Enum;
using C_.Models;

namespace C_.Factory
{
    /// <summary>
    /// Defines the interface for a factory that creates vehicle objects.
    /// This follows the Factory Method design pattern, abstracting the instantiation process.
    /// </summary>
    interface IVehicleFactory
    {
        /// <summary>
        /// Creates a new vehicle instance based on the specified type.
        /// </summary>
        /// <param name="vehicleType">The type of vehicle to create (e.g., CAR, BIKE).</param>
        /// <param name="licensePlate">The license plate of the new vehicle.</param>
        /// <returns>A new <see cref="Vehicle"/> instance of the specified type.</returns>
        Vehicle CreateVehicle(VehicleType vehicleType, string licensePlate);
    }
}
