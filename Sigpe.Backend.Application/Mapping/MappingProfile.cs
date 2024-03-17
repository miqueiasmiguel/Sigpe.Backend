﻿using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MedicamentoDto, Medicamento>()
                .ForMember(e => e.Prescricoes, opt => opt.Ignore())
                .ForMember(e => e.Alergicos, opt => opt.Ignore());
            CreateMap<Medicamento, MedicamentoDto>();
        }
    }
}