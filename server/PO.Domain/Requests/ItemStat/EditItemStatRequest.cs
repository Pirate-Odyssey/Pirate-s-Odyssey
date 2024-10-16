namespace PO.Domain.Requests.ItemStat
{
    public class EditItemStatRequest
    {
        public Guid Id { get; set; }
        public Stats Stats { get; set; }
        public int Value { get; set; }
        public Guid ItemId { get; set; }
    }
}
