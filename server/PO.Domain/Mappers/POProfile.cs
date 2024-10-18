namespace PO.Domain.Mappers
{
    public class POProfile : Profile
    {
        public POProfile()
        {
            #region Item

            // Item
            CreateMap<Item, ItemResponse>().ReverseMap();
            CreateMap<AddItemRequest, Item>().ReverseMap();
            CreateMap<EditItemRequest, Item>().ReverseMap();
            CreateMap<DeleteItemRequest, Item>().ReverseMap();

            // Equipment
            CreateMap<Equipment, EquipmentResponse>().ReverseMap();
            CreateMap<AddEquipmentRequest, Equipment>().ReverseMap();
            CreateMap<EditEquipmentRequest, Equipment>().ReverseMap();
            CreateMap<DeleteEquipmentRequest, Equipment>().ReverseMap();

            // Weapon
            CreateMap<Weapon, WeaponResponse>().ReverseMap();
            CreateMap<AddWeaponRequest, Weapon>().ReverseMap();
            CreateMap<EditWeaponRequest, Weapon>().ReverseMap();
            CreateMap<DeleteWeaponRequest, Weapon>().ReverseMap();

            // EquipableItemStat
            CreateMap<ItemStat, ItemStatResponse>().ReverseMap();
            CreateMap<AddItemStatRequest, ItemStat>().ReverseMap();
            CreateMap<EditItemStatRequest, ItemStat>().ReverseMap();
            CreateMap<DeleteItemStatRequest, ItemStat>().ReverseMap();

            #endregion
        }



    }
}
