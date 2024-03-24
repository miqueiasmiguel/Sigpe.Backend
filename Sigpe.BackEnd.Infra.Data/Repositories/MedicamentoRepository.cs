using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;
using Sigpe.BackEnd.Infra.Data.Context;

namespace Sigpe.BackEnd.Infra.Data.Repositories
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly AppDbContext _context;

        public MedicamentoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Medicamento> CreateAsync(Medicamento entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Medicamento> DeleteAsync(Medicamento entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Medicamento>> GetAsync()
        {
            return await _context.Medicamentos.ToListAsync();
        }

        public async Task<Medicamento?> GetByIdAsync(int id)
        {
            return await _context.Medicamentos.FindAsync(id);
        }

        public async Task<Medicamento?> GetByNomeAsync(string nome)
        {
            return await _context.Medicamentos.FirstOrDefaultAsync(e => e.Nome.ToUpper() == nome.ToUpper());
        }

        public async Task<Medicamento> UpdateAsync(Medicamento entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
