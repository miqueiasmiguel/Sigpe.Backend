using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces.Repositories
{
    public interface IEspecialidadeRepository : IRepository<Especialidade>
    {
        Task<Especialidade?> GetByNomeAsync(string nome);
    }
}
