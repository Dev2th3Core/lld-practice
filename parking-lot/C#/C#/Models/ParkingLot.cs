namespace C_.Models
{
    /// <summary>
    /// Represents a parking lot facility.
    /// </summary>
    class ParkingLot
    {
        private string _name;
        private string _address;

        /// <summary>
        /// Gets or sets the unique identifier for the parking lot.
        /// </summary>
        public Guid LotId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets the name of the parking lot.
        /// </summary>
        public required string Name
        {
            get => _name;
            set => _name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Parking lot name cannot be empty.", nameof(Name));
        }
        /// <summary>
        /// Gets or sets the physical address of the parking lot.
        /// </summary>
        public required string Address
        {
            get => _address;
            set => _address = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Parking lot address cannot be empty.", nameof(Address));
        }
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
