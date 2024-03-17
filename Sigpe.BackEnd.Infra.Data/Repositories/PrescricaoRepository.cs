﻿using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces;
using Sigpe.BackEnd.Infra.Data.Context;

namespace Sigpe.BackEnd.Infra.Data.Repositories
{
    public class PrescricaoRepository : IPrescricaoRepository
    {
        private readonly AppDbContext _context;

        public PrescricaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Prescricao> CreateAsync(Prescricao entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Prescricao> DeleteAsync(Prescricao entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Prescricao>> GetAsync()
        {
            return await _context.Prescricoes.ToListAsync();
        }

        public async Task<Prescricao?> GetByIdAsync(int id)
        {
            return await _context.Prescricoes.FindAsync(id);
        }

        public async Task<Prescricao> UpdateAsync(Prescricao entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
