using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Validation
{
    public class MedicoServiceValidator : IMedicoServiceValidator
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IMedicoRepository _medicoRepository;

        public MedicoServiceValidator(IEspecialidadeRepository especialidadeRepository, IMedicoRepository medicoRepository)
        {
            _especialidadeRepository = especialidadeRepository;
            _medicoRepository = medicoRepository;
        }

        public async Task Validar(MedicoDto dto)
        {
            ValidarObjetoNulo(dto);
            ValidarCamposObrigatorios(dto);
            await ValidarEspecialidade(dto);
            await ValidarMedico(dto);
        }

        private void ValidarObjetoNulo(MedicoDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
        }

        private void ValidarCamposObrigatorios(MedicoDto dto)
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

            if (string.IsNullOrEmpty(dto.Crm))
            {
                throw new Exception($"{nameof(dto.Crm)} é obrigatório.");
            }

            if (!dto.EspecialidadeId.HasValue)
            {
                throw new Exception($"{nameof(dto.EspecialidadeId)} é obrigatório.");
            }
        }

        private async Task ValidarEspecialidade(MedicoDto dto)
        {
            var especialidade = await _especialidadeRepository.GetByIdAsync(dto.EspecialidadeId ?? 0);

            if (especialidade == null)
            {
                throw new Exception("Especialidade não cadastrada.");
            }
        }

        private async Task ValidarMedico(MedicoDto dto)
        {
            if ((dto.Id ?? 0) != 0)
            {
                var medico = await _medicoRepository.GetByIdAsync(dto.Id.Value);

                if (medico == null)
                {
                    throw new Exception("Médico não encontrado.");
                }
            }
        }
    }
}
