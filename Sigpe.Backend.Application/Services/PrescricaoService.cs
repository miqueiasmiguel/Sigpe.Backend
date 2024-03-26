using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Services
{
    public class PrescricaoService : IPrescricaoService
    {
        private readonly IPrescricaoRepository _prescricaoRepository;
        private readonly IPrescricaoServiceValidator _prescricaoServiceValidator;
        private readonly IMapper _mapper;

        public PrescricaoService(IPrescricaoRepository especialidadeRepository, IMapper mapper, IPrescricaoServiceValidator prescricaoServiceValidator)
        {
            _prescricaoRepository = especialidadeRepository;
            _mapper = mapper;
            _prescricaoServiceValidator = prescricaoServiceValidator;
        }

        public async Task<PrescricaoDto> CreateAsync(PrescricaoDto dto)
        {
            await _prescricaoServiceValidator.Validar(dto);

            var prescricao = _mapper.Map<Prescricao>(dto);

            prescricao = await _prescricaoRepository.CreateAsync(prescricao);

            return _mapper.Map<PrescricaoDto>(prescricao);
        }

        public async Task DeleteAsync(int id)
        {
            var prescricao = await _prescricaoRepository.GetByIdAsync(id);

            if (prescricao == null)
            {
                throw new Exception("Prescricao não encontrado.");
            }

            await _prescricaoRepository.DeleteAsync(prescricao);
        }

        public async Task<IEnumerable<PrescricaoDto>> GetAsync()
        {
            var medicamentos = await _prescricaoRepository.GetAsync();

            return _mapper.Map<IEnumerable<PrescricaoDto>>(medicamentos);


        }

        public async Task<PrescricaoDto?> GetByIdAsync(int id)
        {
            var prescricao = await _prescricaoRepository.GetByIdAsync(id);

            if (prescricao == null)
                throw new Exception("Prescrição não encontrada.");

            return _mapper.Map<PrescricaoDto>(prescricao);
        }

        public async Task<List<PrescricaoDto>> GetByMedicoIdAsync(int id)
        {
            await _prescricaoServiceValidator.ValidarExisteMedico(id);

            var prescricoes = await _prescricaoRepository.GetByMedicoIdAsync(id);

            return _mapper.Map<List<PrescricaoDto>>(prescricoes);
        }

        public async Task<List<PrescricaoDto>> GetByPacienteIdAsync(int id)
        {
            await _prescricaoServiceValidator.ValidarExistePaciente(id);

            var prescricoes = await _prescricaoRepository.GetByPacienteIdAsync(id);

            return _mapper.Map<List<PrescricaoDto>>(prescricoes);
        }

        public async Task<PrescricaoDto> UpdateAsync(PrescricaoDto dto)
        {
            await _prescricaoServiceValidator.Validar(dto);

            var prescricao = _mapper.Map<Prescricao>(dto);

            prescricao = await _prescricaoRepository.UpdateAsync(prescricao);

            return _mapper.Map<PrescricaoDto>(prescricao);
        }
    }
}
