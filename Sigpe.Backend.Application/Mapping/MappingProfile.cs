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

            CreateMap<EspecialidadeDto, Especialidade>();
            CreateMap<Especialidade, EspecialidadeDto>();

            CreateMap<MedicamentoDto, Medicamento>();
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
