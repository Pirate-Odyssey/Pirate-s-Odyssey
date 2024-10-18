namespace PO.Domain.Responses.Ship
{
    public class ShipResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MinSeat { get; set; }
        [Required]
        public int MaxSeat { get; set; }
        [Required]
        public double Speed { get; set; }
        [Required]
        public int Health { get; set; }
    }
}
