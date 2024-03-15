using Sigpe.Backend.Domain.Enums;

namespace Sigpe.Backend.Domain.Entities
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Motivo { get; set; }
        public StatusAgendamentoEnum Status { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
