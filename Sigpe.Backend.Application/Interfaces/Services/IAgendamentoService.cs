using Sigpe.Backend.Application.Dtos;

namespace Sigpe.Backend.Application.Interfaces.Services
{
    public interface IAgendamentoService : IService<AgendamentoDto>
    {
        Task<List<AgendamentoDto>> GetByMedicoIdAsync(int id);
        Task<List<AgendamentoDto>> GetByPacienteIdAsync(int id);
    }
}
