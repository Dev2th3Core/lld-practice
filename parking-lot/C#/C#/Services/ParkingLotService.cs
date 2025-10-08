using C_.Enum;
using C_.Models;

namespace C_.Services
{
    class ParkingLotService
    {
        private readonly List<ParkingLot> parkingLots = new List<ParkingLot>();

        public ParkingLot AddParkingLot(string name, string address)
        {
            var lot = new ParkingLot
            {
                LotId = Guid.NewGuid(),
                Name = name,
                Address = address
            };
            parkingLots.Add(lot);
            Console.WriteLine($"Created Parking Lot: {lot.Name} ({lot.LotId}) at {lot.Address}");
            return lot;
        }

        public ParkingLevel AddParkingLevelToLot(Guid lotId)
        {
            var lot = parkingLots.FirstOrDefault(l => l.LotId == lotId);
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

        public ParkingSpot AddParkingSpotToLevel(Guid lotId, Guid levelId, VehicleType type)
        {
            var lot = parkingLots.FirstOrDefault(l => l.LotId == lotId);
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
            Console.WriteLine($"Added Spot {spot.SpotId} ({type}) to Level {level.LevelId}");
            return spot;
        }

        public List<(ParkingLevel Level, ParkingSpot Spot)> GetAvailableSpots(Guid lotId, VehicleType type)
        {
            var lot = parkingLots.FirstOrDefault(l => l.LotId == lotId);
            if (lot == null)
            {
                Console.WriteLine("Parking lot not found!");
                return new List<(ParkingLevel, ParkingSpot)>();
            }

            // LINQ: flatten levels → spots and project both Level + Spot
            var availableSpots = lot.Levels
                .SelectMany(level => level.Spots
                    .Where(spot => spot.Status == SpotStatus.Available && spot.SpotType == type)
                    .Select(spot => (Level: level, Spot: spot)))   // 👈 projection
                .ToList();

            Console.WriteLine($"Found {availableSpots.Count} available {type} spots in Lot {lot.Name}");
            return availableSpots;
        }

        public void DisplayLotStatus(Guid lotId)
        {
            var lot = parkingLots.FirstOrDefault(l => l.LotId == lotId);
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
