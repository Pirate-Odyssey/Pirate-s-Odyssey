namespace PO.Domain.Requests.Weapon
{
    public class AddWeaponRequest : AddItemRequest
    {
        public double Damage { get; set; }
        public TimeSpan Speed { get; set; }
        public bool TwoHanded { get; set; }
    }
}
