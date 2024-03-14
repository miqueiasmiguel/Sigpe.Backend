namespace Sigpe.Backend.Domain.Entities
{
    public class Paciente : Pessoa
    {
        public int PlanoSaudeId { get; set; }
        public PlanoSaude PlanoSaude { get; set; }
        public List<Prescricao> Prescricoes {  get; set; }
        public List<Agendamento> Agendamentos { get; set; }
        public List<Medicamento> Alergias { get; set; }
    }
}
