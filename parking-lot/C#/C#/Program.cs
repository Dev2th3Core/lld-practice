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

            var parkingLotService = new ParkingLotService();

            var lot = parkingLotService.AddParkingLot("City Center Lot", "Downtown");

            var level1 = parkingLotService.AddParkingLevelToLot(lot.LotId);
            var level2 = parkingLotService.AddParkingLevelToLot(lot.LotId);

            var spot1 = parkingLotService.AddParkingSpotToLevel(lot.LotId, level1.LevelId, VehicleType.CAR);
            var spot2 = parkingLotService.AddParkingSpotToLevel(lot.LotId, level1.LevelId, VehicleType.VAN);
            var spot3 = parkingLotService.AddParkingSpotToLevel(lot.LotId, level2.LevelId, VehicleType.BIKE);

            var availableSpots = parkingLotService.GetAvailableSpots(lot.LotId, VehicleType.CAR);
            Console.WriteLine($"\nAvailable Car Spots: {availableSpots.Count}");

            parkingLotService.DisplayLotStatus(lot.LotId);
        }
    }
}
