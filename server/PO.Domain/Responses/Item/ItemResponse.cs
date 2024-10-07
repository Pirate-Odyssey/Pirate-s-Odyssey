namespace PO.Domain.Responses.Item
{
    public class ItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemRarity Rarity { get; set; }
        public int Price { get; set; }
        public ItemType Type { get; set; }

        // FK

        //public virtual ICollection<EquipableItemStat> Stats { get; set; }
    }
}
