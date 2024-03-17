namespace Sigpe.Backend.Application.Interfaces
{
    public interface IService<T>
    {
        public Task<T> CreateAsync(T dto);
        public Task<T> UpdateAsync(T dto);
        public Task<T> DeleteAsync(T dto);
        public Task<IEnumerable<T>> GetAsync();
        public Task<T?> GetByIdAsync(int id);
    }
}
