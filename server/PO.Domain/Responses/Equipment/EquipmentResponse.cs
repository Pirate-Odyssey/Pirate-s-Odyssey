namespace PO.Domain.Responses.Equipment
{
    public class EquipmentResponse : ItemResponse
    {
        [Required]
        public int Armor { get; set; }
        [Required]
        public EquipmentType EquipmentType { get; set; }
    }
}
