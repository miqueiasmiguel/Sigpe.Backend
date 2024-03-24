namespace Sigpe.Backend.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAsync();
        Task<T?> GetByIdAsync(int id);
    }
}
