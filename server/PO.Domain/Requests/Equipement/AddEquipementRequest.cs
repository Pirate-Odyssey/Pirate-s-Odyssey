namespace PO.Domain.Requests.Equipment
{
    public class AddEquipmentRequest : AddItemRequest
    {
        public int Armor { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
