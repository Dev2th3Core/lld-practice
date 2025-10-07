namespace C_.Models
{
    class ParkingLot
    {
        public Guid LotId { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public List<ParkingLevel> Levels { get; set; } = new List<ParkingLevel>();

    }
}
