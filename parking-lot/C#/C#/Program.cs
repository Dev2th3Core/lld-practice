using C_.Enum;
using C_.Models;
using C_.Services;

namespace C_
{
    /// <summary>
    /// The main entry point for the parking lot simulation application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method to run the parking lot simulation.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            try
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

                // Add entrances with coordinates
                var northEntrance = new Entrance { Name = "North Entrance", X = 0, Y = 0, Z = 0 };
                var eastEntrance = new Entrance { Name = "East Entrance", X = 100, Y = 0, Z = 0 };
                lot.Entrances.Add(northEntrance);
                lot.Entrances.Add(eastEntrance);

                var level1 = parkingLotService.AddParkingLevelToLot(lot.LotId);
                var level2 = parkingLotService.AddParkingLevelToLot(lot.LotId);

                // Assign coordinates (x, y, z)
                var spot1 = parkingLotService.AddParkingSpotToLevel(lot.LotId, level1.LevelId, VehicleType.CAR);
                spot1.X = 10; spot1.Y = 0; spot1.Z = 0;

                var spot2 = parkingLotService.AddParkingSpotToLevel(lot.LotId, level1.LevelId, VehicleType.VAN);
                spot2.X = 30; spot2.Y = 0; spot2.Z = 0;

                var spot3 = parkingLotService.AddParkingSpotToLevel(lot.LotId, level2.LevelId, VehicleType.BIKE);
                spot3.X = 5; spot3.Y = 0; spot3.Z = 1;

                var availableSpots = parkingLotService.GetAvailableSpots(lot.LotId, VehicleType.CAR);
                Console.WriteLine($"\nAvailable Car Spots: {availableSpots.Count}");

                parkingLotService.DisplayLotStatus(lot.LotId);

                // --- Reservation demo ---
                var reservationService = new ReservationService(parkingLotService);

                Console.WriteLine("\n--- Reserving Spot for Bob's Car ---");
                //var reservation = reservationService.AutoAssignNearestSpot(
                //    lot.LotId, vehicle2.VehicleId, VehicleType.CAR, northEntrance
                //);

                // Run two threads trying to reserve at the same time
                var t1 = Task.Run(() =>
                {
                    reservationService.AutoAssignNearestSpot(lot.LotId, vehicle1.VehicleId, vehicle1.Type, northEntrance);
                });
                var t2 = Task.Run(() =>
                {
                    reservationService.AutoAssignNearestSpot(lot.LotId, vehicle2.VehicleId, vehicle2.Type, northEntrance);
                });

                Task.WaitAll(t1, t2);

                //Console.WriteLine("\n--- Freeing Spot ---");
                //reservationService.FreeSpot(reservation);
            }
            catch (KeyNotFoundException knfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nERROR: A requested entity was not found. Details: {knfex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex) // Catch any other unexpected exceptions
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nSimulation Complete.");
        }
    }
}
