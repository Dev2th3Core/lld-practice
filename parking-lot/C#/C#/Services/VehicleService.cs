using C_.Enum;
using C_.Models;

namespace C_.Services
{
    class VehicleService
    {
        private readonly List<Vehicle> vehicles = new List<Vehicle>();

        public Vehicle AddVehicle(VehicleType vehicleType, string licensePlate)
        {
            var vehicle = new Vehicle
            {
                Type = vehicleType,
                LicensePlate = licensePlate
            };

            vehicles.Add(vehicle);
            Console.WriteLine($"Vehicle created: {vehicle.Type} (ID: {vehicle.VehicleId}, License: {vehicle.LicensePlate})");
            return vehicle;
        }

        public Vehicle GetVehicleById(Guid vehicleId)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
            if (vehicle is null)
            {
                Console.WriteLine("Vehicle lot not found!");
                return null;
            }
            return vehicle;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return vehicles;
        }

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

        public void DisplayAllVehicles()
        {
            Console.WriteLine("\n--- Registered Vehicles ---");
            
            foreach (var v in vehicles)
                Console.WriteLine($"{v.Type}: {v.LicensePlate}");
        }
    }
}
