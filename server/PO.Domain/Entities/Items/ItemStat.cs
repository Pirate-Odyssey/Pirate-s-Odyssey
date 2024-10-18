namespace PO.Domain.Entities.Items
{
    public class ItemStat
    {
        public Guid Id { get; set; }
        public Stats Stats { get; set; }
        public int Value { get; set; }

        // FK

        public Guid ItemId { get; set; }

        public Item Item { get; set; }
    }
}
