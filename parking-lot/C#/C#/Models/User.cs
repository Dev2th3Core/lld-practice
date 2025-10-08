namespace C_.Models
{
    class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
