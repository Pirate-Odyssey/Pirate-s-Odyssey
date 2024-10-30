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
            CreateMap<ItemResponse, EditItemRequest>().ReverseMap();
            CreateMap<DeleteItemRequest, Item>().ReverseMap();

            // Equipment
            CreateMap<Equipment, EquipmentResponse>().ReverseMap();
            CreateMap<AddEquipmentRequest, Equipment>().ReverseMap();
            CreateMap<EditEquipmentRequest, Equipment>().ReverseMap();
            CreateMap<EquipmentResponse, EditEquipmentRequest>().ReverseMap();
            CreateMap<DeleteEquipmentRequest, Equipment>().ReverseMap();

            // Weapon
            CreateMap<Weapon, WeaponResponse>().ReverseMap();
            CreateMap<AddWeaponRequest, Weapon>().ReverseMap();
            CreateMap<EditWeaponRequest, Weapon>().ReverseMap();
            CreateMap<WeaponResponse, EditWeaponRequest>().ReverseMap();
            CreateMap<DeleteWeaponRequest, Weapon>().ReverseMap();

            // ItemStat
            CreateMap<ItemStat, ItemStatResponse>().ReverseMap();
            CreateMap<AddItemStatRequest, ItemStat>().ReverseMap();
            CreateMap<EditItemStatRequest, ItemStat>().ReverseMap();
            CreateMap<ItemStatResponse, EditItemStatRequest>().ReverseMap();
            CreateMap<DeleteItemStatRequest, ItemStat>().ReverseMap();

            #endregion

            // Ship
            CreateMap<Ship, ShipResponse>().ReverseMap();
            CreateMap<AddShipRequest, Ship>().ReverseMap();
            CreateMap<EditShipRequest, Ship>().ReverseMap();
            CreateMap<ShipResponse, EditShipRequest>().ReverseMap();
            CreateMap<DeleteShipRequest, Ship>().ReverseMap();

            // Crew
            CreateMap<Crew, CrewResponse>().ReverseMap();
            CreateMap<AddCrewRequest, Crew>().ReverseMap();
            CreateMap<EditCrewRequest, Crew>().ReverseMap();
            CreateMap<CrewResponse, EditCrewRequest>().ReverseMap();
            CreateMap<DeleteCrewRequest, Crew>().ReverseMap();

            // CrewMember
            CreateMap<CrewMember, CrewMemberResponse>().ReverseMap();
            CreateMap<AddCrewMemberRequest, CrewMember>().ReverseMap();
            CreateMap<EditCrewMemberRequest, CrewMember>().ReverseMap();
            CreateMap<CrewMemberResponse, EditCrewMemberRequest>().ReverseMap();
            CreateMap<DeleteCrewMemberRequest, CrewMember>().ReverseMap();
        }



    }
}
