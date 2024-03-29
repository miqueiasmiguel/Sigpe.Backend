﻿using Sigpe.Backend.Application.Dtos;

namespace Sigpe.Backend.Application.Interfaces.Services
{
    public interface IUsuarioService : IService<UsuarioDto>
    {
        Task<dynamic> GenerateTokenAsync(LoginDto dto);
    }
}
