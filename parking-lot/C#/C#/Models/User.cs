namespace C_.Models
{
    /// <summary>
    /// Represents a user of the parking lot system.
    /// </summary>
    class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid UserId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the list of vehicles associated with the user.
        /// </summary>
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
