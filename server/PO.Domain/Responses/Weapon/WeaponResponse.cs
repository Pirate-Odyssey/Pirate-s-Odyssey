namespace PO.Domain.Responses.Weapon
{
    public class WeaponResponse : ItemResponse
    {
        [Required]
        public double Damage { get; set; }
        [Required]
        public double Speed { get; set; }
        [Required]
        public bool TwoHanded { get; set; }
    }
}
