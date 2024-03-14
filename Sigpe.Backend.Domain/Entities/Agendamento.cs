namespace Sigpe.Backend.Domain.Entities
{
    public class Agendamento
    {
        public int Int { get; set; }
        public DateTime DataHora { get; set; }
        public string Motivo { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
