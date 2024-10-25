namespace PO.Infrastructure.Repositories
{
    public class CrewRepository(PirateOdysseyContext _context) : ICrewRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        public async Task<int> CountAsync(ISpecification<Crew> specification)
        {
            return await _context.Crews
                .Specify(specification)
                .CountAsync();
        }

        public Crew Create(Crew entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public Crew Delete(Crew entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task<IEnumerable<Crew>> FindAsync(ISpecification<Crew> specification)
        {
            return await _context.Crews
                .Specify(specification)
                .ToListAsync();
        }

        public async Task<Crew> FindOneAsync(ISpecification<Crew> specification)
        {
            return await _context.Crews
                .Specify(specification)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Crew>> GetAllAsync()
        {
            return await _context.Crews
                .ToListAsync();
        }

        public Crew Update(Crew entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
