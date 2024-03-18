using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces;

namespace Sigpe.Backend.Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public MedicoService(IMedicoRepository medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<MedicoDto> CreateAsync(MedicoDto dto)
        {
            var medico = _mapper.Map<Medico>(dto);

            medico = await _medicoRepository.CreateAsync(medico);

            return _mapper.Map<MedicoDto>(medico);
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);

            if (medico == null)
            {
                throw new Exception("Medico não encontrado.");
            }

            await _medicoRepository.DeleteAsync(medico);
        }

        public async Task<IEnumerable<MedicoDto>> GetAsync()
        {
            var medicamentos = await _medicoRepository.GetAsync();

            return _mapper.Map<IEnumerable<MedicoDto>>(medicamentos);


        }

        public async Task<MedicoDto?> GetByIdAsync(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);

            return _mapper.Map<MedicoDto>(medico);
        }

        public async Task<MedicoDto> UpdateAsync(MedicoDto dto)
        {
            var medico = _mapper.Map<Medico>(dto);

            medico = await _medicoRepository.UpdateAsync(medico);

            return _mapper.Map<MedicoDto>(medico);
        }
    }
}
