namespace PO.Domain.Requests.Ship
{
    public class EditShipRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MinSeat { get; set; }
        public int MaxSeat { get; set; }
        public double Speed { get; set; }
        public int Health { get; set; }
    }
}
