using Sigpe.Backend.Domain.Enums;

namespace Sigpe.Backend.Application.Dtos
{
    public class UsuarioDto
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int? PessoaId { get; set; }
        public TipoUsuarioEnum? TipoUsuario { get; set; }
    }
}
