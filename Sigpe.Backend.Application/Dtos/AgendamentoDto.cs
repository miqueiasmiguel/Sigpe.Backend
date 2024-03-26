using Sigpe.Backend.Domain.Enums;

namespace Sigpe.Backend.Application.Dtos
{
    public class AgendamentoDto
    {
        public int? Id { get; set; }
        public DateTime? DataHora { get; set; }
        public string? Motivo { get; set; }
        public StatusAgendamentoEnum? Status { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public PacienteDto? Paciente { get; set; }
        public MedicoDto? Medico { get; set; }
    }
}
