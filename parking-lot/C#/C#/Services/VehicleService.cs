using C_.Enum;
using C_.Factory;
using C_.Models;

namespace C_.Services
{
    /// <summary>
    /// Service for managing vehicle information.
    /// </summary>
    class VehicleService
    {
        private readonly List<Vehicle> _vehicles = new();
        private readonly IVehicleFactory _vehicleFacotry;

        public VehicleService(IVehicleFactory vehicleFacotry)
        {
            _vehicleFacotry = vehicleFacotry;
        }

        /// <summary>
        /// Adds a new vehicle to the system.
        /// </summary>
        /// <param name="vehicleType">The type of the vehicle (e.g., CAR, BIKE).</param>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <returns>The newly created <see cref="Vehicle"/>.</returns>
        public Vehicle AddVehicle(VehicleType vehicleType, string licensePlate)
        {
            var vehicle = _vehicleFacotry.CreateVehicle(vehicleType, licensePlate);

            _vehicles.Add(vehicle);
            Console.WriteLine($"Vehicle created: {vehicle.Type} (ID: {vehicle.VehicleId}, License: {vehicle.LicensePlate})");
            return vehicle;
        }

        /// <summary>
        /// Retrieves a vehicle by its unique identifier.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle.</param>
        /// <returns>The <see cref="Vehicle"/> if found; otherwise, null.</returns>
        public Vehicle GetVehicleById(Guid vehicleId)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
            if (vehicle is null)
            {
                throw new KeyNotFoundException($"Vehicle with ID {vehicleId} not found.");
            }
            return vehicle;
        }

        /// <summary>
        /// Gets a list of all registered vehicles.
        /// </summary>
        /// <returns>A list of all <see cref="Vehicle"/>s.</returns>
        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        /// <summary>
        /// Deletes a vehicle from the system.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to delete.</param>
        /// <returns>True if the vehicle was deleted; otherwise, false.</returns>
        public bool DeleteVehicle(Guid vehicleId)
        {
            var vehicle = GetVehicleById(vehicleId);
            if(vehicle != null)
            {
                Console.WriteLine($"Vehicle deleted: {vehicle.LicensePlate}");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Displays all registered vehicles to the console.
        /// </summary>
        public void DisplayAllVehicles()
        {
            Console.WriteLine("\n--- Registered Vehicles ---");
            
            foreach (var v in _vehicles)
                Console.WriteLine($"{v.Type}: {v.LicensePlate}");
        }
    }
}
