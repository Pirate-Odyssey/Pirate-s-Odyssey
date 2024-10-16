namespace PO.Domain.Responses.Item
{
    public class ItemResponse
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ItemRarity Rarity { get; set; }
        public required int Price { get; set; }
        public required ItemType Type { get; set; }

        // FK

        public virtual ICollection<ItemStatResponse> Stats { get; set; }
    }
}
