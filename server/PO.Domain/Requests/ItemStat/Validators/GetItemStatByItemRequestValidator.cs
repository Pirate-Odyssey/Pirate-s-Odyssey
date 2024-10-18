namespace PO.Domain.Requests.ItemStat.Validators
{
    public class GetItemStatByItemRequestValidator : AbstractValidator<GetItemStatByItemRequest>
    {
        public GetItemStatByItemRequestValidator(IItemRepository itemRepository)
        {
            RuleFor(x => x.ItemId)
                   .NotNull()
                   .MustAsync(async (id, CancellationToken) =>
                   {
                       var spec = new FindItemByIdSpecification(id);
                       var stat = await itemRepository.FindOneAsync(spec);
                       return stat != null;
                   });
        }
    }
}
