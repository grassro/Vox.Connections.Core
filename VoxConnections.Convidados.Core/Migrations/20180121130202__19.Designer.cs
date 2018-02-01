﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180121130202__19")]
    partial class _19
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VoxConnections.Convidados.Core.Candidato", b =>
                {
                    b.Property<int>("IdCandidato")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaAtuacao");

                    b.Property<string>("AreaInteresse");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Celular");

                    b.Property<string>("Cidade");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<bool>("Empregado");

                    b.Property<string>("Esfera");

                    b.Property<string>("Estado");

                    b.Property<int>("IdCurriculo");

                    b.Property<int>("IdIdioma");

                    b.Property<Guid>("IdUsuario");

                    b.Property<string>("NivelEscolaridade");

                    b.Property<string>("NivelFuncao");

                    b.Property<string>("Nome");

                    b.HasKey("IdCandidato");

                    b.HasIndex("IdCurriculo");

                    b.HasIndex("IdUsuario");

                    b.ToTable("tb_Candidato");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Curriculo", b =>
                {
                    b.Property<int>("IdCurriculo")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("CurriculumVitae");

                    b.Property<string>("FileNameCurriculumVitae");

                    b.Property<string>("FileTypeCurriculumVitae");

                    b.HasKey("IdCurriculo");

                    b.ToTable("tb_Curriculo");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Gestor", b =>
                {
                    b.Property<int>("IdGestor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaAtuacao");

                    b.Property<string>("AreaInteresse");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Celular");

                    b.Property<string>("Cidade");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<bool>("Empregado");

                    b.Property<string>("Esfera");

                    b.Property<string>("Estado");

                    b.Property<int>("IdCurriculo");

                    b.Property<int>("IdIdioma");

                    b.Property<Guid>("IdUsuario");

                    b.Property<string>("NivelEscolaridade");

                    b.Property<string>("NivelFuncao");

                    b.Property<string>("Nome");

                    b.HasKey("IdGestor");

                    b.HasIndex("IdCurriculo");

                    b.HasIndex("IdUsuario");

                    b.ToTable("tb_Gestor");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Headhunter", b =>
                {
                    b.Property<int>("IdHeadhunter")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Celular");

                    b.Property<string>("Email");

                    b.Property<string>("Empresa");

                    b.Property<Guid>("IdUsuario");

                    b.Property<string>("Nome");

                    b.HasKey("IdHeadhunter");

                    b.HasIndex("IdUsuario");

                    b.ToTable("tb_Headhunter");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Idioma", b =>
                {
                    b.Property<int>("IdIdioma")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CandidatoIdCandidato");

                    b.Property<int>("CodigoIdioma");

                    b.Property<int?>("GestorIdGestor");

                    b.Property<string>("NivelIdioma");

                    b.Property<string>("NomeIdioma");

                    b.Property<int?>("VagasIdVaga");

                    b.HasKey("IdIdioma");

                    b.HasIndex("CandidatoIdCandidato");

                    b.HasIndex("GestorIdGestor");

                    b.HasIndex("VagasIdVaga");

                    b.ToTable("tb_Idioma");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.IdiomaVaga", b =>
                {
                    b.Property<int>("IdIdioma")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoIdioma");

                    b.Property<string>("NivelIdioma");

                    b.Property<string>("NomeIdioma");

                    b.HasKey("IdIdioma");

                    b.ToTable("tb_Idioma_Vaga");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Cadastrado");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.Property<int>("TipoUsuario");

                    b.HasKey("IdUsuario");

                    b.ToTable("tb_Usuario");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Vagas", b =>
                {
                    b.Property<int>("IdVaga")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaAtuacao");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Cidade");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<int>("IdHeadhunter");

                    b.Property<string>("NivelEscolaridade");

                    b.Property<string>("NivelFuncao");

                    b.Property<string>("TipoContratacao");

                    b.Property<string>("Titulo");

                    b.Property<string>("UF");

                    b.HasKey("IdVaga");

                    b.HasIndex("IdHeadhunter");

                    b.ToTable("tb_Vagas");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.VagasCandidatura", b =>
                {
                    b.Property<int>("IdCandidatura")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdUsuario");

                    b.Property<int>("IdVaga");

                    b.Property<Guid?>("UsuarioIdUsuario");

                    b.HasKey("IdCandidatura");

                    b.HasIndex("IdVaga");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("tb_Candidatura_Vagas");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Candidato", b =>
                {
                    b.HasOne("VoxConnections.Convidados.Core.Curriculo", "Curriculo")
                        .WithMany()
                        .HasForeignKey("IdCurriculo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VoxConnections.Convidados.Core.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Gestor", b =>
                {
                    b.HasOne("VoxConnections.Convidados.Core.Curriculo", "Curriculo")
                        .WithMany()
                        .HasForeignKey("IdCurriculo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VoxConnections.Convidados.Core.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Headhunter", b =>
                {
                    b.HasOne("VoxConnections.Convidados.Core.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Idioma", b =>
                {
                    b.HasOne("VoxConnections.Convidados.Core.Candidato")
                        .WithMany("Idiomas")
                        .HasForeignKey("CandidatoIdCandidato");

                    b.HasOne("VoxConnections.Convidados.Core.Gestor")
                        .WithMany("Idiomas")
                        .HasForeignKey("GestorIdGestor");

                    b.HasOne("VoxConnections.Convidados.Core.Vagas")
                        .WithMany("Idiomas")
                        .HasForeignKey("VagasIdVaga");
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.Vagas", b =>
                {
                    b.HasOne("VoxConnections.Convidados.Core.Headhunter", "Headhunter")
                        .WithMany()
                        .HasForeignKey("IdHeadhunter")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VoxConnections.Convidados.Core.VagasCandidatura", b =>
                {
                    b.HasOne("VoxConnections.Convidados.Core.Vagas", "Vaga")
                        .WithMany()
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VoxConnections.Convidados.Core.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIdUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
