﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sigpe.Backend.Application.Interfaces;
using Sigpe.Backend.Application.Mapping;
using Sigpe.Backend.Application.Services;
using Sigpe.Backend.Domain.Interfaces;
using Sigpe.BackEnd.Infra.Data.Context;
using Sigpe.BackEnd.Infra.Data.Repositories;

namespace Sigpe.Backend.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b =>
                b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IPlanoSaudeRepository, PlanoSaudeRepository>();
            services.AddScoped<IPrescricaoRepository, PrescricaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IEspecialidadeService, EspecialidadeService>();
            services.AddScoped<IMedicamentoService, MedicamentoService>();
            services.AddScoped<IPlanoSaudeService, PlanoSaudeService>();

            return services;
        }
    }
}
