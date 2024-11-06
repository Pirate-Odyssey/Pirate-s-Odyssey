namespace PO.Domain.Services.Implementations
{
    public class ItemStatService(IItemStatRepository itemStatRepository, IMapper mapper) : IItemStatService
    {
        public async Task<ItemStatResponse> AddItemStatAsync(AddItemStatRequest request)
        {
            var itemStat = mapper.Map<ItemStat>(request);
            itemStatRepository.Create(itemStat);
            await itemStatRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ItemStatResponse>(itemStat);
        }

        public async Task<ItemStatResponse> DeleteItemStatAsync(DeleteItemStatRequest request)
        {
            var spec = new FindItemStatByIdSpecification(request.Id);
            var itemStat = await itemStatRepository.FindOneAsync(spec);
            itemStatRepository.Delete(itemStat);
            await itemStatRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ItemStatResponse>(itemStat);
        }

        public async Task<ItemStatResponse> EditItemStatAsync(EditItemStatRequest request)
        {
            var itemStat = mapper.Map<ItemStat>(request);
            itemStatRepository.Update(itemStat);
            await itemStatRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ItemStatResponse>(itemStat);
        }

        public async Task<ItemStatResponse> GetItemStatAsync(GetItemStatByIdRequest request)
        {
            var spec = new FindItemStatByIdSpecification(request.Id);
            var itemStat = await itemStatRepository.FindOneAsync(spec);
            return mapper.Map<ItemStatResponse>(itemStat);
        }

        public async Task<IEnumerable<ItemStatResponse>> GetItemStatsAsync()
        {
            var itemStats = await itemStatRepository.GetAllAsync();
            return itemStats.Select(mapper.Map<ItemStatResponse>);
        }
    }
}
