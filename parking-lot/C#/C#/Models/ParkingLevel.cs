using System.Collections.Concurrent;

namespace C_.Models
{
    /// <summary>
    /// Represents a single level or floor within a parking lot.
    /// </summary>
    class ParkingLevel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the parking level.
        /// </summary>
        public Guid LevelId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets the list of all parking spots on this level.
        /// </summary>
        public List<ParkingSpot> Spots { get; set; } = new List<ParkingSpot>();

        /// <summary>
        /// Gets or sets a thread-safe collection of currently available parking spots on this level.
        /// The key is the SpotId.
        /// </summary>
        public ConcurrentDictionary<Guid, ParkingSpot> AvailableSpots { get; set; } = new ConcurrentDictionary<Guid, ParkingSpot>();
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        => $"Level {LevelId}, Spots: {Spots.Count}";
    }
}
