using Sigpe.Backend.Domain.Enums;

namespace Sigpe.Backend.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
