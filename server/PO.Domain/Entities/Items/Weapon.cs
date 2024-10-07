namespace PO.Domain.Entities.Items
{
    public class Weapon : Item
    {
        public double Damage { get; set; }
        public TimeSpan Speed { get; set; }
        public bool TwoHanded { get; set; }
    }
}
