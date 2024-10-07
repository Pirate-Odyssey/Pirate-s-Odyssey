namespace PO.Domain.Requests.Equipment.Validators
{
    public class AddEquipmentRequestValidator : AbstractValidator<AddEquipmentRequest>
    {
        public AddEquipmentRequestValidator()
        {
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
