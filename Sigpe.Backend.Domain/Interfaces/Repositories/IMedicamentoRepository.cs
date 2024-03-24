using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces.Repositories
{
    public interface IMedicamentoRepository : IRepository<Medicamento>
    {
        Task<Medicamento?> GetByNomeAsync(string nome);
    }
}
