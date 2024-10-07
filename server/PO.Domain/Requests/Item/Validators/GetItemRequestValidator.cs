namespace PO.Domain.Requests.Item.Validators
{
    public class GetItemByIdRequestValidator : AbstractValidator<GetItemByIdRequest>
    {
        public GetItemByIdRequestValidator(IItemRepository itemRepository)
        {
            RuleFor(x => x.Id).MustAsync(async (id, cancellationToken) =>
            {
                var spec = new FindItemByIdSpecification(id);
                var item = await itemRepository.FindOneAsync(spec);
                return item != null;
            })
                .WithMessage("'{PropertyName}' with value '{PropertyValue}' dosen't exist");
        }
    }
}
