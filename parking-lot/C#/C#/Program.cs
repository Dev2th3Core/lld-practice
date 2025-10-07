using C_.Enum;
using C_.Models;
using C_.Services;

namespace C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            var vehicleService = new VehicleService();

            var user1 = userService.AddUser("Alice");
            var vehicle1 = vehicleService.AddVehicle(VehicleType.BIKE, "ABC123");
            
            var user2 = userService.AddUser("Bob");
            var vehicle2 = vehicleService.AddVehicle(VehicleType.CAR, "XYZ789");

            userService.AddVehicleToUser(user1.UserId, vehicle1);
            userService.AddVehicleToUser(user2.UserId, vehicle2);

            userService.DisplayAllUsers();
        }
    }
}
