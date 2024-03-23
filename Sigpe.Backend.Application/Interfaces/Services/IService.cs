namespace Sigpe.Backend.Application.Interfaces.Services
{
    public interface IService<T>
    {
        public Task<T> CreateAsync(T dto);
        public Task<T> UpdateAsync(T dto);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<T>> GetAsync();
        public Task<T?> GetByIdAsync(int id);
    }
}
