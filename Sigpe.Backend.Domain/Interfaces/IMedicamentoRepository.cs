using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces
{
    public interface IMedicamentoRepository : IRepository<Medicamento>
    {
        Task<Medicamento?> GetByNomeAsync(string nome);
    }
}
