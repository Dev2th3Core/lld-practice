namespace C_.Models
{
    class ParkingLot
    {
        public Guid LotId { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Address { get; set; }
        public List<ParkingLevel> Levels { get; set; } = new();
        public List<Entrance> Entrances { get; set; } = new();
        public override string ToString()
        => $"LotId: {LotId}, Name: {Name}, Address: {Address}, Levels: {Levels.Count}";

    }
}
