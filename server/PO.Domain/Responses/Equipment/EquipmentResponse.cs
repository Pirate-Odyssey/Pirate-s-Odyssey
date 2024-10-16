namespace PO.Domain.Responses.Equipment
{
    public class EquipmentResponse : ItemResponse
    {
        public required int Armor { get; set; }
        public required EquipmentType EquipmentType { get; set; }
    }
}
