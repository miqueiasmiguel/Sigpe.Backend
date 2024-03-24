using Sigpe.Backend.Domain.Enums;
using Sigpe.Backend.Domain.Interfaces.Auth;

namespace Sigpe.Backend.Api.Auth
{
    public class CurrentUser : ICurrentUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            var claims = httpContextAccessor.HttpContext.User.Claims;

            if (claims.Any(c => c.Type == "Id"))
            {
                Id = int.Parse(claims.First(c => c.Type == "Id").Value);
            }

            if (claims.Any(c => c.Type == "Email"))
            {
                Email = claims.First(c => c.Type == "Email").Value;
            }

            if (claims.Any(c => c.Type == "TipoUsuario"))
            {
                TipoUsuario = (TipoUsuarioEnum)int.Parse(claims.First(c => c.Type == "TipoUsuario").Value);
            }
        }
    }
}
