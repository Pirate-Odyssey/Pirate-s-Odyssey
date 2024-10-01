namespace PO.Infrastructure.Repositories
{
    public class ItemRepository(PirateOdysseyContext _context) : IItemRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        public async Task<int> CountAsync(ISpecification<Item> specification)
        {
            return await _context.Items
                .Specify(specification)
                .CountAsync();
        }

        public Item Create(Item entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public Item Delete(Item entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task<IEnumerable<Item>> FindAsync(ISpecification<Item> specification)
        {
            return await _context.Items
                .Specify(specification)
                .ToListAsync();
        }

        public async Task<Item> FindOneAsync(ISpecification<Item> specification)
        {
            return await _context.Items
                .Specify(specification)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items
                .ToListAsync();
        }

        public Item Update(Item entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
