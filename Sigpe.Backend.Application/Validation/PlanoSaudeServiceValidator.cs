using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Validation
{
    public class PlanoSaudeServiceValidator : IPlanoSaudeServiceValidator
    {
        private readonly IPlanoSaudeRepository _planoSaudeRepository;

        public PlanoSaudeServiceValidator(IPlanoSaudeRepository planoSaudeRepository)
        {
            _planoSaudeRepository = planoSaudeRepository;
        }

        public async Task Validar(PlanoSaudeDto dto)
        {
            ValidarObjetoNulo(dto);
            ValidarCamposObrigatorios(dto);
            await ValidarObjetoExistente(dto);
        }

        private void ValidarObjetoNulo(PlanoSaudeDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
        }

        private void ValidarCamposObrigatorios(PlanoSaudeDto dto)
        {
            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new Exception($"{nameof(dto.Nome)} é obrigatório.");
            }
        }

        private async Task ValidarObjetoExistente(PlanoSaudeDto dto)
        {
            var planoSaude = await _planoSaudeRepository.GetByNomeAsync(dto.Nome);

            if (planoSaude != null && planoSaude.Id != dto.Id)
            {
                throw new Exception("Já existe outro plano de saúde cadastrado com este nome.");
            }
        }
    }
}
