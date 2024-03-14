namespace Sigpe.Backend.Domain.Entities
{
    public class PlanoSaude
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}
