using PO.Domain.Requests.Item;
using PO.Domain.Responses.Item;

namespace PO.Domain.Mappers
{
    public class POProfile : Profile
    {
        public POProfile()
        {
            #region

            // Item
            CreateMap<Item, ItemResponse>().ReverseMap();
            CreateMap<AddItemRequest, Item>().ReverseMap();
            CreateMap<EditItemRequest, Item>().ReverseMap();
            CreateMap<DeleteItemRequest, Item>().ReverseMap();
            
            #endregion
        }
        


    }
}
