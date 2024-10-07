namespace PO.Domain.Requests.Item.Validators
{
    public class EditItemRequestValidator : AbstractValidator<EditItemRequest>
    {
        public EditItemRequestValidator(IItemRepository itemRepository)
        {
            RuleFor(x => x.Id).MustAsync(async (id, cancellationToken) =>
            {
                var spec = new FindItemByIdSpecification(id);
                var item = await itemRepository.FindOneAsync(spec);
                return item != null;
            })
                .WithMessage("'{PropertyName}' with value '{PropertyValue}' dosen't exist");

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Price).NotEmpty().NotEqual(0);

            RuleFor(x => x.Rarity).NotEmpty().IsInEnum();
        }
    }
}
