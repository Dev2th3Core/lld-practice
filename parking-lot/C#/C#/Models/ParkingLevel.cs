namespace C_.Models
{
    class ParkingLevel
    {
        public Guid LevelId { get; set; } = Guid.NewGuid();
        public List<ParkingSpot> Spots { get; set; } = new List<ParkingSpot>();
        public override string ToString()
        => $"Level {LevelId}, Spots: {Spots.Count}";
    }
}
