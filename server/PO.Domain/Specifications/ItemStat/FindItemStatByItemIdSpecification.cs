namespace PO.Domain.Specifications.ItemStat
{
    public class FindItemStatByItemIdSpecification : Specification<Entities.Items.ItemStat>
    {
        public FindItemStatByItemIdSpecification(Guid itemId)
        {
            Criteria = itemStat => itemStat.ItemId == itemId;
        }
    }
}
