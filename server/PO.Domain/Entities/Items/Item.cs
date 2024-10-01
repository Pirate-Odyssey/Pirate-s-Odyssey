using PO.Domain.Entities.Enums;

namespace PO.Domain.Entities.Items;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemRarity Rarity { get; set; }
    public int Price { get; set; }
}
