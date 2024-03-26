using Sigpe.Backend.Application.Dtos;

namespace Sigpe.Backend.Application.Interfaces.Services
{
    public interface IPrescricaoService : IService<PrescricaoDto>
    {
        Task<List<PrescricaoDto>> GetByMedicoIdAsync(int id);
        Task<List<PrescricaoDto>> GetByPacienteIdAsync(int id);
    }
}
