namespace PO.Domain.Requests.Weapon.Validators
{
    public class EditWeaponRequestValidator : AbstractValidator<EditWeaponRequest>
    {
        public EditWeaponRequestValidator(IWeaponRepository weaponRepository)
        {
            RuleFor(x => x.Id).MustAsync(async (id, cancellationToken) =>
            {
                var spec = new FindWeaponByIdSpecification(id);
                var item = await weaponRepository.FindOneAsync(spec);
                return item != null;
            })
                .WithMessage("'{PropertyName}' with value '{PropertyValue}' dosen't exist");

            // Item
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Price).NotEmpty().NotEqual(0);

            RuleFor(x => x.Rarity).IsInEnum();

            // Weapon
            RuleFor(x => x.Damage)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Speed)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.TwoHanded).NotNull();
        }
    }
}
