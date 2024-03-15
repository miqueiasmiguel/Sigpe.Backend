using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.EntitiesConfiguration
{
    public class PlanoSaudeConfiguration : IEntityTypeConfiguration<PlanoSaude>
    {
        public void Configure(EntityTypeBuilder<PlanoSaude> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Nome)
                .IsRequired();

            builder
                .HasMany(e => e.Pacientes)
                .WithOne(e => e.PlanoSaude)
                .HasForeignKey(e => e.PlanoSaudeId);
        }
    }
}
