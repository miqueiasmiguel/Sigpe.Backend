using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPacienteServiceValidator _pacienteServiceValidator;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper, IPacienteServiceValidator pacienteServiceValidator)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
            _pacienteServiceValidator = pacienteServiceValidator;
        }

        public async Task<PacienteDto> CreateAsync(PacienteDto dto)
        {
            await _pacienteServiceValidator.Validar(dto);

            var paciente = _mapper.Map<Paciente>(dto);

            paciente = await _pacienteRepository.CreateAsync(paciente);

            return _mapper.Map<PacienteDto>(paciente);
        }

        public async Task DeleteAsync(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);

            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado.");
            }

            await _pacienteRepository.DeleteAsync(paciente);
        }

        public async Task<IEnumerable<PacienteDto>> GetAsync()
        {
            var medicamentos = await _pacienteRepository.GetAsync();

            return _mapper.Map<IEnumerable<PacienteDto>>(medicamentos);


        }

        public async Task<PacienteDto?> GetByIdAsync(int id)
        {
            await _pacienteServiceValidator.ValidarPacienteExistente(id);

            var paciente = await _pacienteRepository.GetByIdAsync(id);

            return _mapper.Map<PacienteDto>(paciente);
        }

        public async Task<PacienteDto> UpdateAsync(PacienteDto dto)
        {
            await _pacienteServiceValidator.Validar(dto);

            var paciente = _mapper.Map<Paciente>(dto);

            paciente = await _pacienteRepository.UpdateAsync(paciente);

            return _mapper.Map<PacienteDto>(paciente);
        }
    }
}
