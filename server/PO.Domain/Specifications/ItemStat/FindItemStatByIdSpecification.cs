namespace PO.Domain.Specifications.ItemStat
{
    public class FindItemStatByIdSpecification : Specification<Entities.Items.ItemStat>
    {
        public FindItemStatByIdSpecification(Guid id)
        {
            Criteria = equipableItemStat => equipableItemStat.Id == id;
        }
    }
}
