using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;
using Sigpe.BackEnd.Infra.Data.Context;

namespace Sigpe.BackEnd.Infra.Data.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente> CreateAsync(Paciente entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Paciente> DeleteAsync(Paciente entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Paciente>> GetAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<Paciente> UpdateAsync(Paciente entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
