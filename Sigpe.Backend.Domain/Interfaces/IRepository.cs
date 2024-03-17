namespace Sigpe.Backend.Domain.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public Task<IEnumerable<T>> GetAsync();
        public Task<T?> GetByIdAsync(int id);
    }
}
