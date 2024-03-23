﻿using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces
{
    public interface IPlanoSaudeRepository : IRepository<PlanoSaude>
    {
        Task<PlanoSaude?> GetByNomeAsync(string nome);
    }
}
