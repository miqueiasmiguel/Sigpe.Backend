using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces.Repositories
{
    public interface IPlanoSaudeRepository : IRepository<PlanoSaude>
    {
        Task<PlanoSaude?> GetByNomeAsync(string nome);
    }
}
