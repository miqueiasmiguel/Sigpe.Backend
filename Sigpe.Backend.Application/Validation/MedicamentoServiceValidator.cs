using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Validation
{
    public class MedicamentoServiceValidator : IMedicamentoServiceValidator
    {
        private readonly IMedicamentoRepository _medicamentoRepository;

        public MedicamentoServiceValidator(IMedicamentoRepository medicamentoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
        }

        public async Task Validar(MedicamentoDto dto)
        {
            ValidarObjetoNulo(dto);
            ValidarCamposObrigatorios(dto);
            await ValidarObjetoExistente(dto);
        }

        private void ValidarObjetoNulo(MedicamentoDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
        }

        private void ValidarCamposObrigatorios(MedicamentoDto dto)
        {
            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new Exception($"{nameof(dto.Nome)} é obrigatório.");
            }
        }

        private async Task ValidarObjetoExistente(MedicamentoDto dto)
        {
            var medicamento = await _medicamentoRepository.GetByNomeAsync(dto.Nome);

            if (medicamento != null && medicamento.Id != dto.Id)
            {
                throw new Exception("Já existe outro medicamento cadastrado com este nome.");
            }

            if ((dto.Id ?? 0) != 0)
            {
                medicamento = await _medicamentoRepository.GetByIdAsync(dto.Id.Value);

                if (medicamento == null)
                {
                    throw new Exception("Medicamento não encontrada.");
                }
            }
        }
    }
}
