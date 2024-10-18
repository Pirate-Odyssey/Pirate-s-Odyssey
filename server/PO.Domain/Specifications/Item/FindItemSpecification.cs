namespace PO.Domain.Specifications.Item
{
    public class FindItemSpecification : Specification<Entities.Items.Item>
    {
        public FindItemSpecification()
        {
            Criteria = item => 1 == 1;
        }
    }
}
