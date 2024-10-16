namespace PO.Domain.Responses.Weapon
{
    public class WeaponResponse : ItemResponse
    {
        public required double Damage { get; set; }
        public required double Speed { get; set; }
        public required bool TwoHanded { get; set; }
    }
}
