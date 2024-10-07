namespace PO.Domain.Requests.Weapon.Validators
{
    public class GetWeaponByIdRequestValidator : AbstractValidator<GetWeaponByIdRequest>
    {
        public GetWeaponByIdRequestValidator(IWeaponRepository weaponRepository)
        {
            RuleFor(x => x.Id).MustAsync(async (id, cancellationToken) =>
            {
                var spec = new FindWeaponByIdSpecification(id);
                var item = await weaponRepository.FindOneAsync(spec);
                return item != null;
            })
                .WithMessage("'{PropertyName}' with value '{PropertyValue}' dosen't exist");
        }
    }
}
