namespace PO.Domain.Requests.Item
{
    public class AddItemRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemRarity Rarity { get; set; }
        public int Price { get; set; }
    }
}
