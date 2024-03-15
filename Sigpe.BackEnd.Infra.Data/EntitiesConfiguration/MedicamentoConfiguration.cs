using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.EntitiesConfiguration
{
    public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Nome)
                .IsRequired();

            builder
                .HasMany(e => e.Alergicos)
                .WithMany(e => e.Alergias);
            builder
                .HasMany(e => e.Prescricoes)
                .WithOne(e => e.Medicamento)
                .HasForeignKey(e => e.MedicamentoId);
        }
    }
}
