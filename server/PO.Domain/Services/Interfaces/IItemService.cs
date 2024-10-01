using PO.Domain.Requests.Item;
using PO.Domain.Responses.Item;

namespace PO.Domain.Services.Interfaces
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemResponse>> GetItemsAsync();
        public Task<ItemResponse> GetItemAsync(GetItemByIdRequest request);
        public Task<ItemResponse> AddItemAsync(AddItemRequest request);
        public Task<ItemResponse> EditItemAsync(EditItemRequest request);
        public Task<ItemResponse> DeleteItemAsync(DeleteItemRequest request);
    }
}
