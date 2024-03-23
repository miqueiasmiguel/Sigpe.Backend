namespace Sigpe.Backend.Domain.Interfaces
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
