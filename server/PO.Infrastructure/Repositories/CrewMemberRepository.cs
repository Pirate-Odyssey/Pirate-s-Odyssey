namespace PO.Infrastructure.Repositories
{
    public class CrewMemberRepository(PirateOdysseyContext _context) : ICrewMemberRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        public async Task<int> CountAsync(ISpecification<CrewMember> specification)
        {
            return await _context.CrewMembers
                .Specify(specification)
                .CountAsync();
        }

        public CrewMember Create(CrewMember entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public CrewMember Delete(CrewMember entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task<IEnumerable<CrewMember>> FindAsync(ISpecification<CrewMember> specification)
        {
            return await _context.CrewMembers
                .Specify(specification)
                .ToListAsync();
        }

        public async Task<CrewMember> FindOneAsync(ISpecification<CrewMember> specification)
        {
            return await _context.CrewMembers
                .Specify(specification)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CrewMember>> GetAllAsync()
        {
            return await _context.CrewMembers
                .ToListAsync();
        }

        public CrewMember Update(CrewMember entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
