namespace PO.Domain.Responses.Equipment
{
    public class EquipmentResponse : ItemResponse
    {
        public int Armor { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
