using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Interfaces;

namespace Sigpe.Backend.Application.Validation
{
    public class MedicamentoServiceValidator : IMedicamentoServiceValidator
    {
        private readonly IMedicamentoRepository _medicamentoRepository;

        public MedicamentoServiceValidator(IMedicamentoRepository medicamentoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
        }

        public void Validar(MedicamentoDto dto)
        {
            ValidarObjetoNulo(dto);
            ValidarNome(dto);
            ValidarObjetoExistente(dto);
        }

        private void ValidarObjetoNulo(MedicamentoDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
        }

        private void ValidarNome(MedicamentoDto dto)
        {
            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new Exception("O nome é obrigatório.");
            }
        }

        private async Task ValidarObjetoExistente(MedicamentoDto dto)
        {
            var medicamento = await _medicamentoRepository.GetByNomeAsync(dto.Nome);

            if (medicamento != null)
            {
                throw new Exception("Já existe um medicamento cadastrado com este nome.");
            }
        }
    }
}
