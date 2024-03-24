using Microsoft.EntityFrameworkCore;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Enums;
using Sigpe.Backend.Domain.Interfaces;
using Sigpe.BackEnd.Infra.Data.Context;

namespace Sigpe.BackEnd.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Usuario> DeleteAsync(Usuario entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Usuario>> GetAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Usuario?> GetByPessoaIdTipoAsync(int pessoaId, TipoUsuarioEnum tipo)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(e => e.PessoaId == pessoaId && e.TipoUsuario == tipo);
        }

        public async Task<Usuario?> GetByEmailSenhaAsync(string email, string senha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(e => e.Email.ToUpper() == email.ToUpper() && e.Senha == senha);
        }

        public async Task<Usuario> UpdateAsync(Usuario entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
