namespace PO.Domain.Responses.ItemStat
{
    public class ItemStatResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Stats Stats { get; set; }
        [Required]
        public int Value { get; set; }

        // FK

        [Required]
        public Guid ItemId { get; set; }
        public ItemResponse Item { get; set; }
    }
}
