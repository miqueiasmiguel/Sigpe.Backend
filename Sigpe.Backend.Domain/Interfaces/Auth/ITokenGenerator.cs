using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces.Auth
{
    public interface ITokenGenerator
    {
        dynamic Generate(Usuario usuario);
    }
}
