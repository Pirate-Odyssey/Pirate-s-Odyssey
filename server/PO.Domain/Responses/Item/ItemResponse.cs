namespace PO.Domain.Responses.Item
{
    public class ItemResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ItemRarity Rarity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public ItemType Type { get; set; }

        // FK

        public virtual ICollection<ItemStatResponse> Stats { get; set; }
    }
}
