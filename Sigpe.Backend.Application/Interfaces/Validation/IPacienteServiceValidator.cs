using Sigpe.Backend.Application.Dtos;

namespace Sigpe.Backend.Application.Interfaces.Validation
{
    public interface IPacienteServiceValidator : IServiceValidator<PacienteDto>
    {
        Task ValidarPacienteExistente(int id);
    }
}
