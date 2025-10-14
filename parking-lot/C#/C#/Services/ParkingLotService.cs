using C_.Enum;
using C_.Models;

namespace C_.Services
{
    /// <summary>
    /// Service to manage parking lots, including their levels and spots.
    /// </summary>
    class ParkingLotService
    {
        private readonly List<ParkingLot> _parkingLots = new();

        /// <summary>
        /// Adds a new parking lot to the system.
        /// </summary>
        /// <param name="name">The name of the parking lot.</param>
        /// <param name="address">The address of the parking lot.</param>
        /// <returns>The newly created <see cref="ParkingLot"/>.</returns>
        public ParkingLot AddParkingLot(string name, string address)
        {
            var lot = new ParkingLot
            {
                LotId = Guid.NewGuid(),
                Name = name,
                Address = address
            };
            _parkingLots.Add(lot);
            Console.WriteLine($"Created Parking Lot: {lot.Name} ({lot.LotId}) at {lot.Address}");
            return lot;
        }

        /// <summary>
        /// Retrieves a parking lot by its unique identifier.
        /// </summary>
        /// <param name="lotId">The ID of the parking lot.</param>
        /// <returns>The <see cref="ParkingLot"/> if found; otherwise, null.</returns>
        public ParkingLot GetParkingLotById(Guid lotId)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.LotId == lotId);
            return lot;
        }

        /// <summary>
        /// Adds a new parking level to a specified parking lot.
        /// </summary>
        /// <param name="lotId">The ID of the parking lot.</param>
        /// <returns>The newly created <see cref="ParkingLevel"/> if the lot is found; otherwise, null.</returns>
        public ParkingLevel AddParkingLevelToLot(Guid lotId)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.LotId == lotId);
            if (lot == null)
            {
                Console.WriteLine("Parking lot not found!");
                return null;
            }
            var lotLevel = new ParkingLevel();
            lot.Levels.Add(lotLevel);
            Console.WriteLine($"Added Level {lotLevel.LevelId} to Lot {lot.Name}");
            return lotLevel;
        }

        /// <summary>
        /// Adds a new parking spot to a specified level within a parking lot.
        /// </summary>
        /// <param name="lotId">The ID of the parking lot.</param>
        /// <param name="levelId">The ID of the parking level.</param>
        /// <param name="type">The type of vehicle the spot can accommodate.</param>
        /// <returns>The newly created <see cref="ParkingSpot"/> if the level is found; otherwise, null.</returns>
        public ParkingSpot AddParkingSpotToLevel(Guid lotId, Guid levelId, VehicleType type)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.LotId == lotId);
            var level = lot?.Levels.FirstOrDefault(lv => lv.LevelId == levelId);

            if (level == null)
            {
                Console.WriteLine("❌ Level not found!");
                return null;
            }

            var spot = new ParkingSpot
            {
                SpotType = type,
                LevelId = level.LevelId
            };

            level.Spots.Add(spot);
            level.AvailableSpots.TryAdd(spot.SpotId, spot);
            Console.WriteLine($"Added Spot {spot.SpotId} ({type}) to Level {level.LevelId}");
            return spot;
        }

        /// <summary>
        /// Retrieves a specific parking spot by its ID, within a given lot and level.
        /// </summary>
        /// <param name="lotId">The ID of the parking lot.</param>
        /// <param name="levelId">The ID of the parking level.</param>
        /// <param name="spotId">The ID of the parking spot.</param>
        /// <returns>The <see cref="ParkingSpot"/> if found; otherwise, null.</returns>
        public ParkingSpot GetSpotById(Guid lotId, Guid levelId, Guid spotId)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.LotId == lotId);
            if(lot == null)
            {
                Console.WriteLine("Parking Lot not Found");
                return null;
            }
            var level = lot?.Levels.FirstOrDefault(lv => lv.LevelId == levelId);
            if(level == null)
            {
                Console.WriteLine("Parking Level not Found");
                return null;
            }
            var spot = level.Spots.FirstOrDefault(s => s.SpotId == spotId);
            if(spot == null)
            {
                Console.WriteLine("Parking Spot not Found");
                return null;
            }
            return spot;
        }


        /// <summary>
        /// Gets a list of all available spots for a specific vehicle type in a given parking lot.
        /// </summary>
        /// <param name="lotId">The ID of the parking lot.</param>
        /// <param name="type">The type of vehicle.</param>
        /// <returns>A list of tuples containing the <see cref="ParkingLevel"/> and the available <see cref="ParkingSpot"/>.</returns>
        public List<(ParkingLevel Level, ParkingSpot Spot)> GetAvailableSpots(Guid lotId, VehicleType type)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.LotId == lotId);
            if (lot == null)
            {
                Console.WriteLine("Parking lot not found!");
                return new List<(ParkingLevel, ParkingSpot)>();
            }

            var availableSpots = lot.Levels
                .SelectMany(level => level.AvailableSpots.Values  // read only from AvailableSpots
                    .Where(spot => spot.SpotType == type && spot.Status == SpotStatus.Available)
                    .Select(spot => (Level: level, Spot: spot)))
                .ToList();

            Console.WriteLine($"Found {availableSpots.Count} available {type} spots in Lot {lot.Name}");
            return availableSpots;
        }

        /// <summary>
        /// Displays the current status of a parking lot, including all its levels and spots.
        /// </summary>
        /// <param name="lotId">The ID of the parking lot to display.</param>
        public void DisplayLotStatus(Guid lotId)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.LotId == lotId);
            if(lot == null)
            {
                Console.WriteLine("Not Lot Found");
                return;
            }
            Console.WriteLine("\n===== PARKING LOT STATUS =====");
            Console.WriteLine(lot);
            foreach (var level in lot.Levels)
            {
                Console.WriteLine($"  {level}");
                foreach (var spot in level.Spots)
                    Console.WriteLine($"    {spot}");
            }
        }
    }
}
