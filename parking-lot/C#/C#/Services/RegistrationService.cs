using C_.Enum;
using C_.Models;

namespace C_.Services
{
    /// <summary>
    /// Manages parking spot reservations.
    /// </summary>
    class ReservationService
    {
        private readonly ParkingLotService _parkingLotService;
        private readonly List<Reservation> _reservations = new();
        private static readonly Object _reservationLock = new Object();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationService"/> class.
        /// </summary>
        /// <param name="parkingLotService">The parking lot service to interact with.</param>
        public ReservationService(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        /// <summary>
        /// Finds and reserves the nearest available spot for a given vehicle type, relative to an entrance.
        /// This method is thread-safe.
        /// </summary>
        /// <param name="lotId">The ID of the parking lot.</param>
        /// <param name="vehicleId">The ID of the vehicle making the reservation.</param>
        /// <param name="type">The type of vehicle.</param>
        /// <param name="entrance">The entrance from which to measure distance.</param>
        /// <returns>A <see cref="Reservation"/> object if a spot is successfully reserved; otherwise, null.</returns>
        public Reservation AutoAssignNearestSpot(Guid lotId, Guid vehicleId, VehicleType type, Entrance entrance)
        {
            var lot = _parkingLotService.GetParkingLotById(lotId);
            if (lot == null)
            {
                Console.WriteLine("Invalid parking lot!");
                return null;
            }

            // Take a snapshot of all available spots
            var availableSpots = lot.Levels
                .SelectMany(l => l.AvailableSpots.Values)
                .Where(s => s.SpotType == type)
                .OrderBy(s => Math.Sqrt(
                    Math.Pow(s.X - entrance.X, 2) +
                    Math.Pow(s.Y - entrance.Y, 2) +
                    Math.Pow(s.Z - entrance.Z, 2)
                ))
                .ToList();

            foreach (var spot in availableSpots)
            {
                // Atomically remove spot from available list
                if (lot.Levels.First(l => l.LevelId == spot.LevelId).AvailableSpots.TryRemove(spot.SpotId, out var reservedSpot))
                {
                    reservedSpot.Status = SpotStatus.Reserved;

                    var reservation = new Reservation
                    {
                        ReservationId = Guid.NewGuid(),
                        VehicleId = vehicleId,
                        SpotId = reservedSpot.SpotId,
                        LevelId = reservedSpot.LevelId,
                        LotId = lotId,
                        StartTime = DateTime.Now
                    };

                    Console.WriteLine($"Spot {reservedSpot.SpotId} reserved for Vehicle {vehicleId} at Level {reservedSpot.Z}");
                    return reservation;
                }
                // else, another thread reserved it first, try next spot
            }

            Console.WriteLine("❌ No available spots found!");
            return null;
        }

        /// <summary>
        /// Frees a reserved spot, making it available again.
        /// </summary>
        /// <param name="reservation">The reservation to be ended.</param>
        public void FreeSpot(Reservation reservation)
        {
            var lot = _parkingLotService.GetParkingLotById(reservation.LotId);
            if (lot == null)
            {
                Console.WriteLine("Invalid parking lot!");
                return;
            }

            // Find the spot
            var spot = lot.Levels.SelectMany(l => l.Spots)
                .FirstOrDefault(s => s.SpotId == reservation.SpotId);

            if (spot == null)
            {
                Console.WriteLine("Spot not found!");
                return;
            }

            // Mark the spot as available
            spot.Status = SpotStatus.Available;

            // Re-add to the corresponding level's AvailableSpots
            var level = lot.Levels.First(l => l.LevelId == spot.LevelId);

            // Thread-safe addition if using ConcurrentDictionary
            if (!level.AvailableSpots.ContainsKey(spot.SpotId))
            {
                level.AvailableSpots.TryAdd(spot.SpotId, spot);
            }

            // Remove reservation from active reservations
            _reservations.Remove(reservation);

            Console.WriteLine($"{spot.SpotId} is now available again.");
        }
    }
}
