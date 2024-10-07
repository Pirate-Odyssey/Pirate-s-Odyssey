namespace PO.Infrastructure.Repositories
{
    public class EquipmentRepository(PirateOdysseyContext _context) : IEquipmentRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        public async Task<int> CountAsync(ISpecification<Equipment> specification)
        {
            return await _context.Equipments
                .Specify(specification)
                .CountAsync();
        }

        public Equipment Create(Equipment entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public Equipment Delete(Equipment entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public async Task<IEnumerable<Equipment>> FindAsync(ISpecification<Equipment> specification)
        {
            return await _context.Equipments
                .Specify(specification)
                .ToListAsync();
        }

        public async Task<Equipment> FindOneAsync(ISpecification<Equipment> specification)
        {
            return await _context.Equipments
                .Specify(specification)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments
                .ToListAsync();
        }

        public Equipment Update(Equipment entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
