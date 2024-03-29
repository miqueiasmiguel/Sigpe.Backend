﻿using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Auth;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioServiceValidator _usuarioServiceValidator;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IUsuarioServiceValidator usuarioServiceValidator, ITokenGenerator tokenGenerator)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioServiceValidator = usuarioServiceValidator;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UsuarioDto> CreateAsync(UsuarioDto dto)
        {
            await _usuarioServiceValidator.Validar(dto);

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
            await _usuarioServiceValidator.Validar(dto);

            var usuario = await _usuarioRepository.GetByIdAsync(dto.Id.Value);

            usuario = _mapper.Map<UsuarioDto, Usuario>(dto, usuario);

            var usuarioAlterado = await _usuarioRepository.UpdateAsync(usuario);

            return _mapper.Map<UsuarioDto>(usuarioAlterado);
        }

        public async Task<dynamic> GenerateTokenAsync(LoginDto dto)
        {
            await _usuarioServiceValidator.ValidarLogin(dto);

            var usuario = await _usuarioRepository.GetByEmailSenhaAsync(dto.Email, dto.Senha);

            return _tokenGenerator.Generate(usuario);
        }
    }
}
