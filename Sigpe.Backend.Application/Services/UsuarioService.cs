using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces;

namespace Sigpe.Backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> CreateAsync(UsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            usuario = await _usuarioRepository.CreateAsync(usuario);

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado.");
            }

            await _usuarioRepository.DeleteAsync(usuario);
        }

        public async Task<IEnumerable<UsuarioDto>> GetAsync()
        {
            var medicamentos = await _usuarioRepository.GetAsync();

            return _mapper.Map<IEnumerable<UsuarioDto>>(medicamentos);


        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> UpdateAsync(UsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            usuario = await _usuarioRepository.UpdateAsync(usuario);

            return _mapper.Map<UsuarioDto>(usuario);
        }
    }
}
