using Sigpe.Backend.Domain.Enums;

namespace Sigpe.Backend.Domain.Interfaces.Auth
{
    public interface ICurrentUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}
