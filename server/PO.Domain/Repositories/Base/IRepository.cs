namespace PO.Domain.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; }

        public T Create(T entity);
        public T Update(T entity);
        public T Delete(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<IEnumerable<T>> FindAsync(ISpecification<T> specification);
        public Task<T> FindOneAsync(ISpecification<T> specification);
        public Task<int> CountAsync(ISpecification<T> specification);
    }
}
