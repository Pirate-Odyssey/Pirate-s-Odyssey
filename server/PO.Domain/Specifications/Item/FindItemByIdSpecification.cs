namespace PO.Domain.Specifications.Item
{
    public class FindItemByIdSpecification : Specification<Entities.Items.Item>
    {
        public FindItemByIdSpecification(Guid weaponId)
        {
            Criteria = item => item.Id == weaponId;
        }
    }
}
