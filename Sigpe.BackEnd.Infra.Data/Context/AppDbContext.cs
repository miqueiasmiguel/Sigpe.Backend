using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.BackEnd.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<PlanoSaude> PlanosSaude { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Prescricao> Prescricoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
