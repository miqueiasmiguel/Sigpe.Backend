using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces
{
    public interface IEspecialidadeRepository : IRepository<Especialidade>
    {
        Task<Especialidade?> GetByNomeAsync(string nome);
    }
}
