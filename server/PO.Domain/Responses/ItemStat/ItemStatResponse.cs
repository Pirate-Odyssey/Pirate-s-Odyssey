namespace PO.Domain.Responses.ItemStat
{
    public class ItemStatResponse
    {
        public Guid Id { get; set; }
        public Stats Stats { get; set; }
        public int Value { get; set; }

        // FK

        public Guid ItemId { get; set; }
        public ItemResponse Item { get; set; }
    }
}
