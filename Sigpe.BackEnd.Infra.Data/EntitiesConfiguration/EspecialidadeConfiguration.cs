using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.EntitiesConfiguration
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Nome)
                .IsRequired();
            builder
                .Property(e => e.Descricao)
                .IsRequired(false);

            builder
                .HasMany(e => e.Medicos)
                .WithOne(e => e.Especialidade)
                .HasForeignKey(e => e.EspecialidadeId);
        }
    }
}
