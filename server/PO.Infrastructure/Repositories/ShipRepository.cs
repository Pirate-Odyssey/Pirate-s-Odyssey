namespace PO.Infrastructure.Repositories
{
    public class ShipRepository(PirateOdysseyContext _context) : IShipRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        public async Task<int> CountAsync(ISpecification<Ship> specification)
        {
            return await _context.Ships
                .Specify(specification)
                .CountAsync();
        }

        public Ship Create(Ship entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public Ship Delete(Ship entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task<IEnumerable<Ship>> FindAsync(ISpecification<Ship> specification)
        {
            return await _context.Ships
                .Specify(specification)
                .ToListAsync();
        }

        public async Task<Ship> FindOneAsync(ISpecification<Ship> specification)
        {
            return await _context.Ships
                .Specify(specification)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Ship>> GetAllAsync()
        {
            return await _context.Ships
                .ToListAsync();
        }

        public Ship Update(Ship entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
