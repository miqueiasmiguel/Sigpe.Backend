using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Validation
{
    public class PacienteServiceValidator : IPacienteServiceValidator
    {
        private readonly IPlanoSaudeRepository _planoSaudeRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteServiceValidator(IPlanoSaudeRepository planoSaudeRepository, IPacienteRepository pacienteRepository)
        {
            _planoSaudeRepository = planoSaudeRepository;
            _pacienteRepository = pacienteRepository;
        }

        public async Task Validar(PacienteDto dto)
        {
            ValidarObjetoNulo(dto);
            ValidarCamposObrigatorios(dto);
            await ValidarPlanoSaude(dto);
            await ValidarPaciente(dto);
        }

        private void ValidarObjetoNulo(PacienteDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
        }

        private void ValidarCamposObrigatorios(PacienteDto dto)
        {
            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new Exception($"{nameof(dto.Nome)} é obrigatório.");
            }

            if (!dto.DataNascimento.HasValue)
            {
                throw new Exception($"{nameof(dto.DataNascimento)} é obrigatório.");
            }

            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new Exception($"{nameof(dto.Nome)} é obrigatório.");
            }

            if (string.IsNullOrEmpty(dto.Endereco))
            {
                throw new Exception($"{nameof(dto.Endereco)} é obrigatório.");
            }

            if (string.IsNullOrEmpty(dto.Endereco))
            {
                throw new Exception($"{nameof(dto.Endereco)} é obrigatório.");
            }

            if (string.IsNullOrEmpty(dto.Telefone))
            {
                throw new Exception($"{nameof(dto.Telefone)} é obrigatório.");
            }

            if (!dto.PlanoSaudeId.HasValue)
            {
                throw new Exception($"{nameof(dto.PlanoSaudeId)} é obrigatório.");
            }
        }

        private async Task ValidarPlanoSaude(PacienteDto dto)
        {
            var planoSaude = await _planoSaudeRepository.GetByIdAsync(dto.PlanoSaudeId ?? 0);

            if (planoSaude != null)
            {
                throw new Exception("Plano de saúde não cadastrado.");
            }
        }

        private async Task ValidarPaciente(PacienteDto dto)
        {
            if ((dto.Id ?? 0) != 0)
            {
                await ValidarPacienteExistente(dto.Id.Value);
            }
        }

        public async Task ValidarPacienteExistente(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);

            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado.");
            }
        }
    }
}
