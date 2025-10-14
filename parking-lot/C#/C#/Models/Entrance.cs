namespace C_.Models
{
    /// <summary>
    /// Represents an entrance to the parking lot, used for calculating proximity.
    /// </summary>
     class Entrance
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entrance.
        /// </summary>
        public Guid EntranceId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets the name of the entrance (e.g., "North Entrance").
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the X-coordinate of the entrance.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the Y-coordinate of the entrance.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the Z-coordinate of the entrance, typically at ground level (0).
        /// </summary>
        public double Z { get; set; } = 0; // Usually at ground level
    }

}
