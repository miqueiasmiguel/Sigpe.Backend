using AutoMapper;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Domain.Entities;

namespace Sigpe.Backend.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AgendamentoDto, Agendamento>();
            CreateMap<Agendamento, AgendamentoDto>();

            CreateMap<EspecialidadeDto, Especialidade>()
                .ForMember(e => e.Medicos, opt => opt.Ignore());
            CreateMap<Especialidade, EspecialidadeDto>();

            CreateMap<MedicamentoDto, Medicamento>()
                .ForMember(e => e.Prescricoes, opt => opt.Ignore())
                .ForMember(e => e.Alergicos, opt => opt.Ignore());
            CreateMap<Medicamento, MedicamentoDto>();

            CreateMap<MedicoDto, Medico>();
            CreateMap<Medico, MedicoDto>();

            CreateMap<PacienteDto, Paciente>();
            CreateMap<Paciente, PacienteDto>();

            CreateMap<PlanoSaudeDto, PlanoSaude>();
            CreateMap<PlanoSaude, PlanoSaudeDto>();

            CreateMap<PrescricaoDto, Prescricao>();
            CreateMap<Prescricao, PrescricaoDto>();

            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
