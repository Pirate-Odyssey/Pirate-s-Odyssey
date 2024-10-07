namespace PO.Domain.Requests.Weapon.Validators
{
    public class AddWeaponRequestValidator : AbstractValidator<AddWeaponRequest>
    {
        public AddWeaponRequestValidator()
        {
            // Item
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Price).NotEmpty().NotEqual(0);

            RuleFor(x => x.Rarity).NotEmpty().IsInEnum();

            // Weapon
            RuleFor(x => x.Damage)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Speed)
                .NotEmpty()
                .NotNull()
                .GreaterThan(new TimeSpan(0, 0, 0));

            RuleFor(x => x.TwoHanded).NotNull();
        }
    }
}
