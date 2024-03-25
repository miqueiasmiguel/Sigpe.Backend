﻿using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Validation
{
    public class PrescricaoServiceValidator : IPrescricaoServiceValidator
    {
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public PrescricaoServiceValidator(IMedicamentoRepository medicamentoRepository, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
        {
            _medicamentoRepository = medicamentoRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
        }

        public async Task Validar(PrescricaoDto dto)
        {
            ValidarCamposObrigatorios(dto);
            await ValidarMedicamento(dto);
            await ValidarMedico(dto);
            await ValidarPaciente(dto);
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

        private async Task ValidarMedicamento(PrescricaoDto dto)
        {
            var medicamento = await _medicamentoRepository.GetByIdAsync(dto.MedicamentoId.Value);

            if (medicamento == null)
            {
                throw new Exception("Medicamento não encontrado");
            }
        }

        private async Task ValidarMedico(PrescricaoDto dto)
        {
            var medico = await _medicoRepository.GetByIdAsync(dto.MedicoId.Value);

            if (medico == null)
            {
                throw new Exception("Medico não encontrado");
            }
        }

        private async Task ValidarPaciente(PrescricaoDto dto)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(dto.PacienteId.Value);

            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado");
            }

            if (paciente.Alergias.Any(m => m.Id == dto.MedicamentoId))
            {
                throw new Exception("O paciente é alergico a este medicamento.");
            }
        }
    }
}
