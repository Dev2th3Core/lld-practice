namespace C_.Models
{
     class Entrance
    {
        public Guid EntranceId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; } = 0; // Usually at ground level
    }

}
