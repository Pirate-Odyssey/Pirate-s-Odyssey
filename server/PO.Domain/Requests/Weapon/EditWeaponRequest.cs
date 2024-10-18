namespace PO.Domain.Requests.Weapon
{
    public class EditWeaponRequest : EditItemRequest
    {
        public double Damage { get; set; }
        public double Speed { get; set; }
        public bool TwoHanded { get; set; }
    }
}
