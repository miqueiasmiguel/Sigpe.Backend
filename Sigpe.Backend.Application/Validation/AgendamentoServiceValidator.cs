using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Validation
{
    public class AgendamentoServiceValidator : IAgendamentoServiceValidator
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public AgendamentoServiceValidator(IAgendamentoRepository agendamentoRepository, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
        }

        public async Task Validar(AgendamentoDto dto)
        {
            ValidarCamposObrigatorios(dto);
            await ValidarPaciente(dto);
            await ValidarMedico(dto);
            await ValidarAgendamento(dto);
        }

        private void ValidarCamposObrigatorios(AgendamentoDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            if (!dto.DataHora.HasValue)
            {
                throw new ArgumentException($"{nameof(dto.DataHora)} é obrigatório.");
            }

            if (!dto.Status.HasValue)
            {
                throw new ArgumentException($"{nameof(dto.Status)} é obrigatório.");
            }

            if (!dto.PacienteId.HasValue)
            {
                throw new ArgumentException($"{nameof(dto.PacienteId)} é obrigatório.");
            }

            if (!dto.MedicoId.HasValue)
            {
                throw new ArgumentException($"{nameof(dto.MedicoId)} é obrigatório.");
            }
        }

        private async Task ValidarAgendamento(AgendamentoDto dto)
        {
            if ((dto.Id ?? 0) != 0)
            {
                await ValidarAgendamentoExistente(dto.Id.Value);
            }

            var agendamento = await _agendamentoRepository.VerificarDisponibilidade(dto.DataHora.Value, dto.MedicoId.Value, dto.Id ?? 0);

            if (agendamento != null)
            {
                throw new Exception("Médico ocupado neste horário.");
            }
        }

        private async Task ValidarAgendamentoExistente(int id)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(id);

            if (agendamento == null)
            {
                throw new Exception("Agendamento não encontrado.");
            }
        }

        private async Task ValidarMedico(AgendamentoDto dto)
        {
            var medico = await _medicoRepository.GetByIdAsync(dto.MedicoId.Value);

            if (medico == null)
            {
                throw new Exception("Médico não encontrado.");
            }
        }

        private async Task ValidarPaciente(AgendamentoDto dto)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(dto.PacienteId.Value);

            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado.");
            }
        }

        public async Task ValidarExisteMedico(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);

            if (medico == null)
            {
                throw new Exception("Medico não encontrado");
            }
        }

        public async Task<Paciente> ValidarExistePaciente(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);

            return paciente ?? throw new Exception("Paciente não encontrado");
        }
    }
}
