using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces.Repositories;

namespace Sigpe.Backend.Application.Services
{
    public class PlanoSaudeService : IPlanoSaudeService
    {
        private readonly IPlanoSaudeRepository _planoSaudeRepository;
        private readonly IPlanoSaudeServiceValidator _planoSaudeServiceValidator;
        private readonly IMapper _mapper;

        public PlanoSaudeService(IPlanoSaudeRepository planoSaudeRepository, IMapper mapper, IPlanoSaudeServiceValidator planoSaudeServiceValidator)
        {
            _planoSaudeRepository = planoSaudeRepository;
            _mapper = mapper;
            _planoSaudeServiceValidator = planoSaudeServiceValidator;
        }

        public async Task<PlanoSaudeDto> CreateAsync(PlanoSaudeDto dto)
        {
            await _planoSaudeServiceValidator.Validar(dto);

            var planoSaude = _mapper.Map<PlanoSaude>(dto);

            planoSaude = await _planoSaudeRepository.CreateAsync(planoSaude);

            return _mapper.Map<PlanoSaudeDto>(planoSaude);
        }

        public async Task DeleteAsync(int id)
        {
            var planoSaude = await _planoSaudeRepository.GetByIdAsync(id);

            if (planoSaude == null)
            {
                throw new Exception("Plano de saúde não encontrado.");
            }

            await _planoSaudeRepository.DeleteAsync(planoSaude);
        }

        public async Task<IEnumerable<PlanoSaudeDto>> GetAsync()
        {
            var medicamentos = await _planoSaudeRepository.GetAsync();

            return _mapper.Map<IEnumerable<PlanoSaudeDto>>(medicamentos);


        }

        public async Task<PlanoSaudeDto?> GetByIdAsync(int id)
        {
            var planoSaude = await _planoSaudeRepository.GetByIdAsync(id);

            return _mapper.Map<PlanoSaudeDto>(planoSaude);
        }

        public async Task<PlanoSaudeDto> UpdateAsync(PlanoSaudeDto dto)
        {
            await _planoSaudeServiceValidator.Validar(dto);

            var planoSaude = _mapper.Map<PlanoSaude>(dto);

            planoSaude = await _planoSaudeRepository.UpdateAsync(planoSaude);

            return _mapper.Map<PlanoSaudeDto>(planoSaude);
        }
    }
}
