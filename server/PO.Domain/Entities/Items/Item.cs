namespace PO.Domain.Entities.Items;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemRarity Rarity { get; set; }
    public int Price { get; set; }

    // Discriminator

    public ItemType Type { get; set; }

    // FK

    public virtual ICollection<EquipableItemStat> Stats { get; set; }
}
