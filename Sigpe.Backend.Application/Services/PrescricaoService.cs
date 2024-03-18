using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces;

namespace Sigpe.Backend.Application.Services
{
    public class PrescricaoService : IPrescricaoService
    {
        private readonly IPrescricaoRepository _prescricaoRepository;
        private readonly IMapper _mapper;

        public PrescricaoService(IPrescricaoRepository especialidadeRepository, IMapper mapper)
        {
            _prescricaoRepository = especialidadeRepository;
            _mapper = mapper;
        }

        public async Task<PrescricaoDto> CreateAsync(PrescricaoDto dto)
        {
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

            return _mapper.Map<PrescricaoDto>(prescricao);
        }

        public async Task<PrescricaoDto> UpdateAsync(PrescricaoDto dto)
        {
            var prescricao = _mapper.Map<Prescricao>(dto);

            prescricao = await _prescricaoRepository.UpdateAsync(prescricao);

            return _mapper.Map<PrescricaoDto>(prescricao);
        }
    }
}
