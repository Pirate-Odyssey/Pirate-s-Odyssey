using PO.Domain.Responses.Item;

namespace PO.Domain.Responses.Weapon
{
    public class WeaponResponse : ItemResponse
    {
        public double Damage { get; set; }
        public TimeSpan Speed { get; set; }
        public bool TwoHanded { get; set; }
    }
}
