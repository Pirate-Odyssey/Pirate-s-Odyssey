namespace PO.Domain.Specifications.Item
{
    public class FindItemByIdSpecification : Specification<Entities.Items.Item>
    {
        public FindItemByIdSpecification(Guid itemId)
        {
            Criteria = item => item.Id == itemId;
        }
    }
}
