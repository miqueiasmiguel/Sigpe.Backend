using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.EntitiesConfiguration
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
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
                .Property(e => e.EspecialidadeId)
                .IsRequired();

            builder
                .HasOne(e => e.Especialidade)
                .WithMany(e => e.Medicos)
                .HasForeignKey(e => e.EspecialidadeId);
            builder
                .HasMany(e => e.Agendamentos)
                .WithOne(e => e.Medico)
                .HasForeignKey(e => e.MedicoId);
            builder
                .HasMany(e => e.Prescricoes)
                .WithOne(e => e.Medico)
                .HasForeignKey(e => e.MedicoId);
        }
    }
}
