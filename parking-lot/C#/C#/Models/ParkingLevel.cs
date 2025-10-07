namespace C_.Models
{
    class ParkingLevel
    {
        public Guid LevelId { get; set; }
        public List<ParkingSpot> Spots { get; set; } = new List<ParkingSpot>();
    }
}
