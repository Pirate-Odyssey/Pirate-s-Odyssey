namespace PO.Domain.Requests.Equipment
{
    public class EditEquipmentRequest : EditItemRequest
    {
        public int Armor { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
