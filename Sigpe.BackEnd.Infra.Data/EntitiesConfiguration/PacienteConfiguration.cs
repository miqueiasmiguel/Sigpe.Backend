using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.EntitiesConfiguration
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Nome)
                .IsRequired();
            builder
                .Property(e => e.DataNascimento)
                .IsRequired();
            builder
                .Property(e => e.Endereco)
                .IsRequired();
            builder
                .Property(e => e.Telefone)
                .IsRequired();
            builder
                .Property(e => e.PlanoSaudeId)
                .IsRequired(false);

            builder
                .HasOne(e => e.PlanoSaude)
                .WithMany(e => e.Pacientes)
                .HasForeignKey(e => e.PlanoSaudeId);
            builder
                .HasMany(e => e.Prescricoes)
                .WithOne(e => e.Paciente)
                .HasForeignKey(e => e.PacienteId);
            builder
                .HasMany(e => e.Agendamentos)
                .WithOne(e => e.Paciente)
                .HasForeignKey(e => e.PacienteId);
            builder
                .HasMany(e => e.Alergias)
                .WithMany(e => e.Alergicos);
        }
    }
}
