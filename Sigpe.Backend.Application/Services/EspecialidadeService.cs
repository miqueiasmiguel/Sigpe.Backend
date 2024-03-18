﻿using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces;
using Sigpe.Backend.Domain.Entities;
using Sigpe.Backend.Domain.Interfaces;

namespace Sigpe.Backend.Application.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IMapper _mapper;

        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository, IMapper mapper)
        {
            _especialidadeRepository = especialidadeRepository;
            _mapper = mapper;
        }

        public async Task<EspecialidadeDto> CreateAsync(EspecialidadeDto dto)
        {
            var especialidade = _mapper.Map<Especialidade>(dto);

            especialidade = await _especialidadeRepository.CreateAsync(especialidade);

            return _mapper.Map<EspecialidadeDto>(especialidade);
        }

        public async Task DeleteAsync(int id)
        {
            var especialidade = await _especialidadeRepository.GetByIdAsync(id);

            if (especialidade == null)
            {
                throw new Exception("Especialidade não encontrado.");
            }

            await _especialidadeRepository.DeleteAsync(especialidade);
        }

        public async Task<IEnumerable<EspecialidadeDto>> GetAsync()
        {
            var medicamentos = await _especialidadeRepository.GetAsync();

            return _mapper.Map<IEnumerable<EspecialidadeDto>>(medicamentos);


        }

        public async Task<EspecialidadeDto?> GetByIdAsync(int id)
        {
            var especialidade = await _especialidadeRepository.GetByIdAsync(id);

            return _mapper.Map<EspecialidadeDto>(especialidade);
        }

        public async Task<EspecialidadeDto> UpdateAsync(EspecialidadeDto dto)
        {
            var especialidade = _mapper.Map<Especialidade>(dto);

            especialidade = await _especialidadeRepository.UpdateAsync(especialidade);

            return _mapper.Map<EspecialidadeDto>(especialidade);
        }
    }
}
