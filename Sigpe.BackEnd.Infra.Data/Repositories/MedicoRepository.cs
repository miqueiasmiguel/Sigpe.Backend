using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;
using Sigpe.BackEnd.Infra.Data.Context;

namespace Sigpe.BackEnd.Infra.Data.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly AppDbContext _context;

        public MedicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Medico> CreateAsync(Medico entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Medico> DeleteAsync(Medico entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Medico>> GetAsync()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task<Medico?> GetByIdAsync(int id)
        {
            return await _context.Medicos.FindAsync(id);
        }

        public async Task<Medico> UpdateAsync(Medico entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
