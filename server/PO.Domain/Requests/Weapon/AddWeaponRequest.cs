namespace PO.Domain.Requests.Weapon
{
    public class AddWeaponRequest : AddItemRequest
    {
        public double Damage { get; set; }
        public double Speed { get; set; }
        public bool TwoHanded { get; set; }
    }
}
