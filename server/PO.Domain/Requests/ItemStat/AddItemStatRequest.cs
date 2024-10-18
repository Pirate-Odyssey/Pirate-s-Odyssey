namespace PO.Domain.Requests.ItemStat
{
    public class AddItemStatRequest
    {
        public Stats Stats { get; set; }
        public int Value { get; set; }
        public Guid ItemId { get; set; }
    }
}
