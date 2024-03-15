﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sigpe.BackEnd.Infra.Data.Context;

#nullable disable

namespace Sigpe.BackEnd.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedicamentoPaciente", b =>
                {
                    b.Property<int>("AlergiasId")
                        .HasColumnType("integer");

                    b.Property<int>("AlergicosId")
                        .HasColumnType("integer");

                    b.HasKey("AlergiasId", "AlergicosId");

                    b.HasIndex("AlergicosId");

                    b.ToTable("MedicamentoPaciente");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MedicoId")
                        .HasColumnType("integer");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PacienteId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeId");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PlanoSaudeId")
                        .HasColumnType("integer");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlanoSaudeId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.PlanoSaude", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PlanosSaude");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Prescricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Instrucoes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("MedicoId")
                        .HasColumnType("integer");

                    b.Property<int>("PacienteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentoId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Prescricoes");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MedicamentoPaciente", b =>
                {
                    b.HasOne("Sigpe.Backend.Domain.Entities.Medicamento", null)
                        .WithMany()
                        .HasForeignKey("AlergiasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigpe.Backend.Domain.Entities.Paciente", null)
                        .WithMany()
                        .HasForeignKey("AlergicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Agendamento", b =>
                {
                    b.HasOne("Sigpe.Backend.Domain.Entities.Medico", "Medico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigpe.Backend.Domain.Entities.Paciente", "Paciente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Medico", b =>
                {
                    b.HasOne("Sigpe.Backend.Domain.Entities.Especialidade", "Especialidade")
                        .WithMany("Medicos")
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Paciente", b =>
                {
                    b.HasOne("Sigpe.Backend.Domain.Entities.PlanoSaude", "PlanoSaude")
                        .WithMany("Pacientes")
                        .HasForeignKey("PlanoSaudeId");

                    b.Navigation("PlanoSaude");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Prescricao", b =>
                {
                    b.HasOne("Sigpe.Backend.Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("Prescricoes")
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigpe.Backend.Domain.Entities.Medico", "Medico")
                        .WithMany("Prescricoes")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigpe.Backend.Domain.Entities.Paciente", "Paciente")
                        .WithMany("Prescricoes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Especialidade", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Medicamento", b =>
                {
                    b.Navigation("Prescricoes");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Medico", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Prescricoes");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.Paciente", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Prescricoes");
                });

            modelBuilder.Entity("Sigpe.Backend.Domain.Entities.PlanoSaude", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
