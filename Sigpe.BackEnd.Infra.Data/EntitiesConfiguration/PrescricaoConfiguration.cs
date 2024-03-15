using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.EntitiesConfiguration
{
    public class PrescricaoConfiguration : IEntityTypeConfiguration<Prescricao>
    {
        public void Configure(EntityTypeBuilder<Prescricao> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Data)
                .IsRequired();
            builder
                .Property(e => e.Instrucoes)
                .IsRequired();
            builder
                .Property(e => e.MedicamentoId)
                .IsRequired();
            builder
                .Property(e => e.PacienteId)
                .IsRequired();
            builder
                .Property(e => e.MedicoId)
                .IsRequired();

            builder
                .HasOne(e => e.Medicamento)
                .WithMany(e => e.Prescricoes)
                .HasForeignKey(e => e.MedicamentoId);
            builder
                .HasOne(e => e.Paciente)
                .WithMany(e => e.Prescricoes)
                .HasForeignKey(e => e.PacienteId);
            builder
                .HasOne(e => e.Medico)
                .WithMany(e => e.Prescricoes)
                .HasForeignKey(e => e.MedicoId);
        }
    }
}
