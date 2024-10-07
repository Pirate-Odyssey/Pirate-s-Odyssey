namespace PO.Domain.Requests.Equipment.Validators
{
    public class DeleteEquipmentRequestValidator : AbstractValidator<DeleteEquipmentRequest>
    {
        public DeleteEquipmentRequestValidator(IEquipmentRepository equipmentRepository)
        {
            RuleFor(x => x.Id).MustAsync(async (id, cancellationToken) =>
            {
                var spec = new FindEquipmentByIdSpecification(id);
                var item = await equipmentRepository.FindOneAsync(spec);
                return item != null;
            })
               .WithMessage("'{PropertyName}' with value '{PropertyValue}' dosen't exist");
        }
    }
}
