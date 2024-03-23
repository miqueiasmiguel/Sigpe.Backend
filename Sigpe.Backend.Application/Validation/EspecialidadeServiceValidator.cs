using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Interfaces;

namespace Sigpe.Backend.Application.Validation
{
    public class EspecialidadeServiceValidator : IEspecialidadeServiceValidator
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeServiceValidator(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        public async Task Validar(EspecialidadeDto dto)
        {
            ValidarObjetoNulo(dto);
            ValidarCamposObrigatorios(dto);
            await ValidarObjetoExistente(dto);
        }

        private void ValidarObjetoNulo(EspecialidadeDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
        }

        private void ValidarCamposObrigatorios(EspecialidadeDto dto)
        {
            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new Exception($"{nameof(dto.Nome)} é obrigatório.");
            }

            if (string.IsNullOrEmpty(dto.Descricao))
            {
                throw new Exception($"{nameof(dto.Descricao)} é obrigatório.");
            }
        }

        private async Task ValidarObjetoExistente(EspecialidadeDto dto)
        {
            var especialidade = await _especialidadeRepository.GetByNomeAsync(dto.Nome);

            if (especialidade != null && especialidade.Id != dto.Id)
            {
                throw new Exception("Já existe outra especialidade cadastrada com este nome.");
            }
        }
    }
}
