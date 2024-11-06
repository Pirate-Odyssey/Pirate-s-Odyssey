namespace PO.Domain.Services.Implementations
{
    public class ItemService(IItemRepository itemRepository, IMapper mapper) : IItemService
    {
        public async Task<ItemResponse> AddItemAsync(AddItemRequest request)
        {
            var item = mapper.Map<Item>(request);
            itemRepository.Create(item);
            await itemRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ItemResponse>(item);
        }

        public async Task<ItemResponse> DeleteItemAsync(DeleteItemRequest request)
        {
            var spec = new FindItemByIdSpecification(request.Id);
            var item = await itemRepository.FindOneAsync(spec);
            itemRepository.Delete(item);
            await itemRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ItemResponse>(item);
        }

        public async Task<ItemResponse> EditItemAsync(EditItemRequest request)
        {
            var item = mapper.Map<Item>(request);
            itemRepository.Update(item);
            await itemRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ItemResponse>(item);
        }

        public async Task<ItemResponse> GetItemAsync(GetItemByIdRequest request)
        {
            var spec = new FindItemByIdSpecification(request.Id);
            spec.AddInclude(i => i.Stats);
            var item = await itemRepository.FindOneAsync(spec);
            return mapper.Map<ItemResponse>(item);
        }

        public async Task<IEnumerable<ItemResponse>> GetItemsAsync()
        {
            var spec = new FindItemSpecification();
            var items = await itemRepository.FindAsync(spec);
            return items.Select(mapper.Map<ItemResponse>);
        }
    }
}
