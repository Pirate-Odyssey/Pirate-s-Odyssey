namespace PO.Domain.Specifications.Equipment
{
    public class FindEquipmentByIdSpecification : Specification<Entities.Items.Equipment>
    {
        public FindEquipmentByIdSpecification(Guid equipmentId)
        {
            Criteria = equipment => equipment.Id == equipmentId;
        }
    }
}
