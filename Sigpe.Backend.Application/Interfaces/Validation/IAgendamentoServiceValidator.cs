using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Application.Interfaces.Validation
{
    public interface IAgendamentoServiceValidator : IServiceValidator<AgendamentoDto>
    {
        Task ValidarExisteMedico(int id);
        Task<Paciente> ValidarExistePaciente(int id);
    }
}
