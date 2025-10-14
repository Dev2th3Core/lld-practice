namespace C_.Models
{
    /// <summary>
    /// Represents a parking lot facility.
    /// </summary>
    class ParkingLot
    {
        /// <summary>
        /// Gets or sets the unique identifier for the parking lot.
        /// </summary>
        public Guid LotId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets the name of the parking lot.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Gets or sets the physical address of the parking lot.
        /// </summary>
        public required string Address { get; set; }
        /// <summary>
        /// Gets or sets the list of levels within the parking lot.
        /// </summary>
        public List<ParkingLevel> Levels { get; set; } = new();
        /// <summary>
        /// Gets or sets the list of entrances to the parking lot.
        /// </summary>
        public List<Entrance> Entrances { get; set; } = new();
        public override string ToString()
        => $"LotId: {LotId}, Name: {Name}, Address: {Address}, Levels: {Levels.Count}";

    }
}
