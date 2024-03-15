using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.EntitiesConfiguration
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.DataHora)
                .IsRequired();
            builder
                .Property(e => e.Motivo)
                .IsRequired();
            builder
                .Property(e => e.Status)
                .IsRequired();
            builder
                .Property(e => e.PacienteId)
                .IsRequired();
            builder
                .Property(e => e.MedicoId)
                .IsRequired();

            builder
                .HasOne(e => e.Paciente)
                .WithMany(e => e.Agendamentos)
                .HasForeignKey(e => e.PacienteId);
            builder
                .HasOne(e => e.Medico)
                .WithMany(e => e.Agendamentos)
                .HasForeignKey(e => e.MedicoId);
        }
    }
}
