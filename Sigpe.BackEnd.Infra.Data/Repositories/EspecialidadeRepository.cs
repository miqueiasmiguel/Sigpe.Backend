using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;
using Sigpe.BackEnd.Infra.Data.Context;

namespace Sigpe.BackEnd.Infra.Data.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly AppDbContext _context;

        public EspecialidadeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Especialidade> CreateAsync(Especialidade entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Especialidade> DeleteAsync(Especialidade entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Especialidade>> GetAsync()
        {
            return await _context.Especialidades.ToListAsync();
        }

        public async Task<Especialidade?> GetByIdAsync(int id)
        {
            return await _context.Especialidades.FindAsync(id);
        }

        public async Task<Especialidade?> GetByNomeAsync(string nome)
        {
            return await _context.Especialidades.FirstOrDefaultAsync(e => e.Nome.ToUpper() == nome.ToUpper());
        }

        public async Task<Especialidade> UpdateAsync(Especialidade entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
