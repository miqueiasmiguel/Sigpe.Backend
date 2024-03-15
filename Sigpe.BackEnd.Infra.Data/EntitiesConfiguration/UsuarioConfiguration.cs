using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Email)
                .IsRequired();
            builder
                .Property(e => e.Senha)
                .IsRequired();
            builder
                .Property(e => e.PessoaId)
                .IsRequired(false);
            builder
                .Property(e => e.TipoUsuario);
        }
    }
}
