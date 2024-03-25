using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;

namespace Sigpe.Backend.Application.Validation
{
    public class PrescricaoServiceValidator : IPrescricaoServiceValidator
    {
        public async Task Validar(PrescricaoDto dto)
        {
            ValidarCamposObrigatorios(dto);
        }

        private void ValidarCamposObrigatorios(PrescricaoDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (!dto.Data.HasValue)
            {
                throw new ArgumentException($"{nameof(dto.Data)} é obrigatório.");
            }

            if (string.IsNullOrEmpty(dto.Instrucoes))
            {
                throw new ArgumentException($"{nameof(dto.Instrucoes)} é obrigatório.");
            }

            if (!dto.MedicamentoId.HasValue)
            {
                throw new ArgumentException($"{nameof(dto.MedicamentoId)} é obrigatório.");
            }

            if (!dto.PacienteId.HasValue)
            {
                throw new ArgumentException($"{nameof(dto.PacienteId)} é obrigatório.");
            }

            if (!dto.MedicoId.HasValue)
            {
                throw new ArgumentException($"{nameof(dto.MedicoId)} é obrigatório.");
            }
        }
    }
}
