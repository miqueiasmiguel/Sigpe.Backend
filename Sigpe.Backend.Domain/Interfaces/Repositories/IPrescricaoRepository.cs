using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces.Repositories
{
    public interface IPrescricaoRepository : IRepository<Prescricao>
    {
        Task<List<Prescricao>> GetByMedicoIdAsync(int id);
        Task<List<Prescricao>> GetByPacienteIdAsync(int id);
    }
}
