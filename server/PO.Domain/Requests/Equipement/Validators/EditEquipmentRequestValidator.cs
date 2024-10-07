namespace PO.Domain.Requests.Equipment.Validators
{
    public class EditEquipmentRequestValidator : AbstractValidator<EditEquipmentRequest>
    {
        public EditEquipmentRequestValidator(IWeaponRepository weaponRepository)
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

            RuleFor(x => x.Rarity).NotEmpty().IsInEnum();

            // Equipment
            RuleFor(x => x.EquipmentType).NotEmpty().IsInEnum();

            RuleFor(x => x.Armor).NotEmpty().NotEqual(0);
        }
    }
}
