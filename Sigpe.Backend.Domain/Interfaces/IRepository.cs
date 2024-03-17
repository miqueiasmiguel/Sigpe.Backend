namespace Sigpe.Backend.Domain.Interfaces
{
    public interface IRepository<T>
    {
        public T Create(T entity);
        public T Update(T entity);
        public T Delete(T entity);
        public List<T> Get();
        public T GetById(int id);
    }
}
