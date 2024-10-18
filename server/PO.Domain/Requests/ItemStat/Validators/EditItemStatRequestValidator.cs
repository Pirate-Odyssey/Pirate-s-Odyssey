namespace PO.Domain.Requests.ItemStat.Validators
{
    public class EditItemStatRequestValidator : AbstractValidator<EditItemStatRequest>
    {
        public EditItemStatRequestValidator(IItemStatRepository equipableItemStatRepository, IItemRepository itemRepository)
        {
            RuleFor(x => x.Id)
                .NotNull()
                .MustAsync(async (id, CancellationToken) =>
                {
                    var spec = new FindItemStatByIdSpecification(id);
                    var stat = await equipableItemStatRepository.FindOneAsync(spec);
                    return stat != null;
                });

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
