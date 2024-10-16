namespace PO.Domain.Requests.ItemStat.Validators
{
    public class AddItemStatRequestValidator : AbstractValidator<AddItemStatRequest>
    {
        public AddItemStatRequestValidator(IItemRepository itemRepository)
        {
            RuleFor(x => x.Value)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Stats)
                .NotNull()
                .IsInEnum();

            RuleFor(x => x.ItemId)
                .NotNull()
                .MustAsync(async (id, CancellationToken) =>
                {
                    var spec = new FindItemByIdSpecification(id);
                    var item = await itemRepository.FindOneAsync(spec);
                    return item != null;
                });
        }
    }
}
