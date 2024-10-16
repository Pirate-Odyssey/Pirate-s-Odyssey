namespace PO.Infrastructure.Repositories
{
    public class ItemStatRepository(PirateOdysseyContext _context) : IItemStatRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        public async Task<int> CountAsync(ISpecification<ItemStat> specification)
        {
            return await _context.ItemStats
                .Specify(specification)
                .CountAsync();
        }

        public ItemStat Create(ItemStat entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public ItemStat Delete(ItemStat entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task<IEnumerable<ItemStat>> FindAsync(ISpecification<ItemStat> specification)
        {
            return await _context.ItemStats
                .Specify(specification)
                .ToListAsync();
        }

        public async Task<ItemStat> FindOneAsync(ISpecification<ItemStat> specification)
        {
            return await _context.ItemStats
                .Specify(specification)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ItemStat>> GetAllAsync()
        {
            return await _context.ItemStats
                .ToListAsync();
        }

        public ItemStat Update(ItemStat entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
