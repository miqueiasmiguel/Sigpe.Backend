namespace Sigpe.Backend.Domain.Entities
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Paciente> Alergicos { get; set; }
        public List<Prescricao> Prescricoes { get; set; }
    }
}
