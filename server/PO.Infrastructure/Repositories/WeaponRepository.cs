namespace PO.Infrastructure.Repositories
{
    public class WeaponRepository(PirateOdysseyContext _context) : IWeaponRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        public async Task<int> CountAsync(ISpecification<Weapon> specification)
        {
            return await _context.Weapons
                .Specify(specification)
                .CountAsync();
        }

        public Weapon Create(Weapon entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public Weapon Delete(Weapon entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task<IEnumerable<Weapon>> FindAsync(ISpecification<Weapon> specification)
        {
            return await _context.Weapons
                .Specify(specification)
                .ToListAsync();
        }

        public async Task<Weapon> FindOneAsync(ISpecification<Weapon> specification)
        {
            return await _context.Weapons
                .Specify(specification)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Weapon>> GetAllAsync()
        {
            return await _context.Weapons
                .ToListAsync();
        }

        public Weapon Update(Weapon entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
