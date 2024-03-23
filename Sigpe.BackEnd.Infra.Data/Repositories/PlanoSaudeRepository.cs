using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces;
using Sigpe.BackEnd.Infra.Data.Context;

namespace Sigpe.BackEnd.Infra.Data.Repositories
{
    public class PlanoSaudeRepository : IPlanoSaudeRepository
    {
        private readonly AppDbContext _context;

        public PlanoSaudeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PlanoSaude> CreateAsync(PlanoSaude entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<PlanoSaude> DeleteAsync(PlanoSaude entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<PlanoSaude>> GetAsync()
        {
            return await _context.PlanosSaude.ToListAsync();
        }

        public async Task<PlanoSaude?> GetByIdAsync(int id)
        {
            return await _context.PlanosSaude.FindAsync(id);
        }

        public async Task<PlanoSaude?> GetByNomeAsync(string nome)
        {
            return await _context.PlanosSaude.FirstOrDefaultAsync(e => e.Nome.ToUpper() == nome.ToUpper());
        }

        public async Task<PlanoSaude> UpdateAsync(PlanoSaude entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
