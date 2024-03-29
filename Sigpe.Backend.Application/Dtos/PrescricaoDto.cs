﻿using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Application.Dtos
{
    public class PrescricaoDto
    {
        public int? Id { get; set; }
        public DateTime? Data { get; set; }
        public string? Instrucoes { get; set; }
        public int? MedicamentoId { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public MedicamentoDto? Medicamento { get; set; }
        public PacienteDto? Paciente { get; set; }
        public MedicoDto? Medico { get; set; }
    }
}
