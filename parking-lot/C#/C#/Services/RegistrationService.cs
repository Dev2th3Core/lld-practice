using C_.Enum;
using C_.Models;

namespace C_.Services
{
    class ReservationService
    {
        private readonly ParkingLotService _parkingLotService;
        private readonly List<Reservation> _reservations = new();

        public ReservationService(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        public Reservation AutoAssignNearestSpot(Guid lotId, Guid vehicleId, VehicleType type, Entrance entrance)
        {
            var lot = _parkingLotService.GetParkingLotById(lotId);
            if (lot == null)
            {
                Console.WriteLine("Invalid parking lot!");
                return null;
            }

            var availableSpots = lot.Levels
                .SelectMany(level => level.Spots)
                .Where(s => s.SpotType == type && s.Status == SpotStatus.Available)
                .ToList();

            if (!availableSpots.Any())
            {
                Console.WriteLine("No available spots found for this vehicle type!");
                return null;
            }

            // Find nearest spot using 3D Euclidean distance
            var nearestSpot = availableSpots
                .OrderBy(s => Math.Sqrt(
                    Math.Pow(s.X - entrance.X, 2) +
                    Math.Pow(s.Y - entrance.Y, 2) +
                    Math.Pow(s.Z - entrance.Z, 2)
                ))
                .FirstOrDefault();

            nearestSpot.Status = SpotStatus.Reserved;

            var reservation = new Reservation
            {
                ReservationId = Guid.NewGuid(),
                VehicleId = vehicleId,
                SpotId = nearestSpot.SpotId,
                LevelId = nearestSpot.LevelId,
                LotId = lotId,
                StartTime = DateTime.Now
            };

            _reservations.Add(reservation);

            Console.WriteLine(
                $"Spot {nearestSpot.SpotId} reserved for Vehicle {vehicleId} " +
                $"at Level {nearestSpot.Z}, Coords ({nearestSpot.X},{nearestSpot.Y},{nearestSpot.Z}) " +
                $"near Entrance '{entrance.Name}'."
            );

            return reservation;
        }

        public void FreeSpot(Reservation reservation)
        {
            var lot = _parkingLotService.GetParkingLotById(reservation.LotId);
            if (lot == null)
            {
                Console.WriteLine("Invalid parking lot!");
                return;
            }

            var spot = lot.Levels.SelectMany(l => l.Spots)
                .FirstOrDefault(s => s.SpotId == reservation.SpotId);

            if (spot == null)
            {
                Console.WriteLine("Spot not found!");
                return;
            }

            spot.Status = SpotStatus.Available;
            Console.WriteLine($"{spot.SpotId} is now available again.");
            _reservations.Remove(reservation);
        }
    }
}
