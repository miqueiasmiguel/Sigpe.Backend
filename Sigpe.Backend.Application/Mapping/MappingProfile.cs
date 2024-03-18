using AutoMapper;
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

            CreateMap<EspecialidadeDto, Especialidade>()
                .ForMember(e => e.Medicos, opt => opt.Ignore());
            CreateMap<Especialidade, EspecialidadeDto>();

            CreateMap<PlanoSaudeDto, PlanoSaude>();
            CreateMap<PlanoSaude, PlanoSaudeDto>();
        }
    }
}
