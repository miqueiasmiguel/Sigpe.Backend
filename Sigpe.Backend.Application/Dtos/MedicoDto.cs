using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Application.Dtos
{
    public class MedicoDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Crm { get; set; }
        public int? EspecialidadeId { get; set; }
    }
}
