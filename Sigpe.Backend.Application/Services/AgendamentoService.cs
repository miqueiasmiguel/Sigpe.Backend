using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Enums;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IAgendamentoServiceValidator _agendamentoServiceValidator;
        private readonly IMapper _mapper;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IMapper mapper, IAgendamentoServiceValidator agendamentoServiceValidator)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
            _agendamentoServiceValidator = agendamentoServiceValidator;
        }

        public async Task<AgendamentoDto> CreateAsync(AgendamentoDto dto)
        {
            await _agendamentoServiceValidator.Validar(dto);

            var agendamento = _mapper.Map<Agendamento>(dto);

            agendamento.Status = StatusAgendamentoEnum.SOLICITADO;

            agendamento = await _agendamentoRepository.CreateAsync(agendamento);

            return _mapper.Map<AgendamentoDto>(agendamento);
        }

        public async Task DeleteAsync(int id)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(id);

            if (agendamento == null)
            {
                throw new Exception("Agendamento não encontrado.");
            }

            await _agendamentoRepository.DeleteAsync(agendamento);
        }

        public async Task<IEnumerable<AgendamentoDto>> GetAsync()
        {
            var medicamentos = await _agendamentoRepository.GetAsync();

            return _mapper.Map<IEnumerable<AgendamentoDto>>(medicamentos);


        }

        public async Task<AgendamentoDto?> GetByIdAsync(int id)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(id);

            return _mapper.Map<AgendamentoDto>(agendamento);
        }

        public async Task<AgendamentoDto> UpdateAsync(AgendamentoDto dto)
        {
            await _agendamentoServiceValidator.Validar(dto);

            var agendamento = _mapper.Map<Agendamento>(dto);

            agendamento = await _agendamentoRepository.UpdateAsync(agendamento);

            return _mapper.Map<AgendamentoDto>(agendamento);
        }
    }
}
