using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Enums;

namespace Sigpe.Backend.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario?> GetByPessoaIdTipoAsync(int pessoaId, TipoUsuarioEnum tipo);
        Task<Usuario?> GetByEmailSenhaAsync(string email, string senha);
    }
}
