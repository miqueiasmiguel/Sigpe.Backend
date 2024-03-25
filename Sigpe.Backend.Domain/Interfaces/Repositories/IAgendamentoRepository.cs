﻿using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Domain.Interfaces.Repositories
{
    public interface IAgendamentoRepository : IRepository<Agendamento>
    {
        Task<Agendamento?> VerificarDisponibilidade(DateTime data, int medicoId, int id);
    }
}
