using Microsoft.IdentityModel.Tokens;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sigpe.BackEnd.Infra.Data.Auth
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generate(Usuario usuario)
        {
            List<Claim> claims = new()
            {
                new Claim("Email", usuario.Email),
                new Claim("Id", usuario.Id.ToString()),
                new Claim("Tipo", usuario.TipoUsuario.GetHashCode().ToString()),
                new Claim("PessoaId", usuario.PessoaId.ToString() ?? string.Empty)
            };

            DateTime expires = DateTime.Now.AddDays(1);
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SYMMETRIC_SECURITY_KEY")));
            JwtSecurityToken tokenData = new(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenData);

            return new
            {
                token,
                expires
            };
        }
    }
}
