namespace PO.Domain.Services.Interfaces
{
    public interface IItemStatService
    {
        public Task<IEnumerable<ItemStatResponse>> GetItemStatsAsync();
        public Task<ItemStatResponse> GetItemStatAsync(GetItemStatByIdRequest request);
        public Task<ItemStatResponse> AddItemStatAsync(AddItemStatRequest request);
        public Task<ItemStatResponse> EditItemStatAsync(EditItemStatRequest request);
        public Task<ItemStatResponse> DeleteItemStatAsync(DeleteItemStatRequest request);
    }
}
