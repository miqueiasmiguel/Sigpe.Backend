using Sigpe.Backend.Domain.Enums;

namespace Sigpe.Backend.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? PessoaId { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}
