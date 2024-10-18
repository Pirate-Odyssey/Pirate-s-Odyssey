namespace PO.Domain.Requests.ItemStat.Validators
{
    public class GetItemStatByIdRequestValidator : AbstractValidator<GetItemStatByIdRequest>
    {
        public GetItemStatByIdRequestValidator(IItemStatRepository equipableItemStatRepository)
        {
            RuleFor(x => x.Id)
                .NotNull()
                .MustAsync(async (id, CancellationToken) =>
                {
                    var spec = new FindItemStatByIdSpecification(id);
                    var stat = await equipableItemStatRepository.FindOneAsync(spec);
                    return stat != null;
                });
        }
    }
}
