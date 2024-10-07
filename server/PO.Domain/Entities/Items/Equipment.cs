namespace PO.Domain.Entities.Items;

public class Equipment : Item
{
    public int Armor { get; set; }
    public EquipmentType EquipmentType { get; set; }
}
