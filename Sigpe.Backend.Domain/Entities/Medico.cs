namespace Sigpe.Backend.Domain.Entities
{
    public class Medico : Pessoa
    {
        public string Crm { get; set; }
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
        public List<Prescricao> Prescricoes { get; set; }
    }
}
