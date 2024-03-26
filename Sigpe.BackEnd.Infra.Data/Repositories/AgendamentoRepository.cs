using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Enums;
using Sigpe.Backend.Domain.Interfaces.Repositories;
using Sigpe.BackEnd.Infra.Data.Context;

namespace Sigpe.BackEnd.Infra.Data.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly AppDbContext _context;

        public AgendamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Agendamento> CreateAsync(Agendamento entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Agendamento> DeleteAsync(Agendamento entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Agendamento>> GetAsync()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await _context.Agendamentos
                                    .Include(e => e.Medico)
                                    .Include(e => e.Paciente)
                                    .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Agendamento>> GetByMedicoIdAsync(int id)
        {
            return await _context.Agendamentos
                                    .Include(e => e.Paciente)
                                    .Where(e => e.MedicoId == id)
                                    .ToListAsync();
        }

        public async Task<List<Agendamento>> GetByPacienteIdAsync(int id)
        {
            return await _context.Agendamentos
                                    .Include(e => e.Medico)
                                    .Include(e => e.Medico)
                                    .Where(e => e.PacienteId == id)
                                    .ToListAsync();
        }

        public async Task<Agendamento?> VerificarDisponibilidade(DateTime data, int medicoId, int id)
        {
            return await _context.Agendamentos.FirstOrDefaultAsync(e => e.DataHora <= data.AddMinutes(30)
                                                                     && e.DataHora >= data.AddMinutes(-30)
                                                                     && e.Status.Equals(StatusAgendamentoEnum.SOLICITADO)
                                                                     && e.Id != id);
        }

        public async Task<Agendamento> UpdateAsync(Agendamento entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
