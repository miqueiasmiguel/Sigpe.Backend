namespace Sigpe.Backend.Domain.Entities
{
    public class Prescricao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Instrucoes { get; set; }
        public string Observacoes { get; set; }
        public int MedicamentoId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
