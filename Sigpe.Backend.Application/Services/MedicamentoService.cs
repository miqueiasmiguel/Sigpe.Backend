using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;
using Sigpe.Backend.Application.Interfaces.Validation;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces;

namespace Sigpe.Backend.Application.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly IMedicamentoServiceValidator _medicamentoServiceValidator;
        private readonly IMapper _mapper;

        public MedicamentoService(IMedicamentoRepository medicamentoRepository, IMapper mapper, IMedicamentoServiceValidator medicamentoServiceValidator)
        {
            _medicamentoRepository = medicamentoRepository;
            _mapper = mapper;
            _medicamentoServiceValidator = medicamentoServiceValidator;
        }

        public async Task<MedicamentoDto> CreateAsync(MedicamentoDto dto)
        {
            _medicamentoServiceValidator.Validar(dto);

            var medicamento = _mapper.Map<Medicamento>(dto);

            medicamento = await _medicamentoRepository.CreateAsync(medicamento);

            return _mapper.Map<MedicamentoDto>(medicamento);
        }

        public async Task DeleteAsync(int id)
        {
            var medicamento = await _medicamentoRepository.GetByIdAsync(id);

            if (medicamento == null)
            {
                throw new Exception("Medicamento não encontrado.");
            }

            await _medicamentoRepository.DeleteAsync(medicamento);
        }

        public async Task<IEnumerable<MedicamentoDto>> GetAsync()
        {
            var medicamentos = await _medicamentoRepository.GetAsync();

            return _mapper.Map<IEnumerable<MedicamentoDto>>(medicamentos);
        }

        public async Task<MedicamentoDto?> GetByIdAsync(int id)
        {
            var medicamento = await _medicamentoRepository.GetByIdAsync(id);

            return _mapper.Map<MedicamentoDto>(medicamento);
        }

        public async Task<MedicamentoDto> UpdateAsync(MedicamentoDto dto)
        {
            var medicamento = _mapper.Map<Medicamento>(dto);

            medicamento = await _medicamentoRepository.UpdateAsync(medicamento);

            return _mapper.Map<MedicamentoDto>(medicamento);
        }
    }
}
