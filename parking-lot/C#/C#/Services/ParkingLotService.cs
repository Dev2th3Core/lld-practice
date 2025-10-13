using C_.Enum;
using C_.Models;

namespace C_.Services
{
    class ParkingLotService
    {
        private readonly List<ParkingLot> _parkingLots = new();

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

        public ParkingLot GetParkingLotById(Guid lotId)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.LotId == lotId);
            return lot;
        }

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
            Console.WriteLine($"Added Spot {spot.SpotId} ({type}) to Level {level.LevelId}");
            return spot;
        }

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


        public List<(ParkingLevel Level, ParkingSpot Spot)> GetAvailableSpots(Guid lotId, VehicleType type)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.LotId == lotId);
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
