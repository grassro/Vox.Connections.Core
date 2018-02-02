using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VoxConnections.Convidados.Core.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Curriculo",
                columns: table => new
                {
                    IdCurriculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurriculumVitae = table.Column<byte[]>(nullable: true),
                    FileNameCurriculumVitae = table.Column<string>(nullable: true),
                    FileTypeCurriculumVitae = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Curriculo", x => x.IdCurriculo);
                });

            migrationBuilder.CreateTable(
                name: "tb_Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Cadastrado = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_Candidato",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaAtuacao = table.Column<string>(nullable: true),
                    AreaExecutiva = table.Column<string>(nullable: true),
                    AreaInteresse = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Empregado = table.Column<bool>(nullable: false),
                    Empresa = table.Column<string>(nullable: true),
                    Esfera = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Formacao = table.Column<string>(nullable: true),
                    IdCurriculo = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    NivelEscolaridade = table.Column<string>(nullable: true),
                    NivelFuncao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Candidato", x => x.IdCandidato);
                    table.ForeignKey(
                        name: "FK_tb_Candidato_tb_Curriculo_IdCurriculo",
                        column: x => x.IdCurriculo,
                        principalTable: "tb_Curriculo",
                        principalColumn: "IdCurriculo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Candidato_tb_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tb_Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Gestor",
                columns: table => new
                {
                    IdGestor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaAtuacao = table.Column<string>(nullable: true),
                    AreaExecutiva = table.Column<string>(nullable: true),
                    AreaInteresse = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Empregado = table.Column<bool>(nullable: false),
                    Empresa = table.Column<string>(nullable: true),
                    Esfera = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Formacao = table.Column<string>(nullable: true),
                    IdCurriculo = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    NivelEscolaridade = table.Column<string>(nullable: true),
                    NivelFuncao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Gestor", x => x.IdGestor);
                    table.ForeignKey(
                        name: "FK_tb_Gestor_tb_Curriculo_IdCurriculo",
                        column: x => x.IdCurriculo,
                        principalTable: "tb_Curriculo",
                        principalColumn: "IdCurriculo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Gestor_tb_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tb_Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Headhunter",
                columns: table => new
                {
                    IdHeadhunter = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Empresa = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Headhunter", x => x.IdHeadhunter);
                    table.ForeignKey(
                        name: "FK_tb_Headhunter_tb_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tb_Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Idioma_Candidato",
                columns: table => new
                {
                    IdIdioma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCandidato = table.Column<int>(nullable: false),
                    NivelIdioma = table.Column<string>(nullable: true),
                    NomeIdioma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Idioma_Candidato", x => x.IdIdioma);
                    table.ForeignKey(
                        name: "FK_tb_Idioma_Candidato_tb_Candidato_IdCandidato",
                        column: x => x.IdCandidato,
                        principalTable: "tb_Candidato",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Idioma_Gestor",
                columns: table => new
                {
                    IdIdioma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdGestor = table.Column<int>(nullable: false),
                    NivelIdioma = table.Column<string>(nullable: true),
                    NomeIdioma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Idioma_Gestor", x => x.IdIdioma);
                    table.ForeignKey(
                        name: "FK_tb_Idioma_Gestor_tb_Gestor_IdGestor",
                        column: x => x.IdGestor,
                        principalTable: "tb_Gestor",
                        principalColumn: "IdGestor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Vagas",
                columns: table => new
                {
                    IdVaga = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaAtuacao = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Cidade = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdHeadhunter = table.Column<int>(nullable: false),
                    NivelEscolaridade = table.Column<string>(nullable: true),
                    NivelFuncao = table.Column<string>(nullable: true),
                    TipoContratacao = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Vagas", x => x.IdVaga);
                    table.ForeignKey(
                        name: "FK_tb_Vagas_tb_Headhunter_IdHeadhunter",
                        column: x => x.IdHeadhunter,
                        principalTable: "tb_Headhunter",
                        principalColumn: "IdHeadhunter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Candidatura_Vagas",
                columns: table => new
                {
                    IdCandidatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<string>(nullable: true),
                    IdVaga = table.Column<int>(nullable: false),
                    UsuarioIdUsuario = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Candidatura_Vagas", x => x.IdCandidatura);
                    table.ForeignKey(
                        name: "FK_tb_Candidatura_Vagas_tb_Vagas_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "tb_Vagas",
                        principalColumn: "IdVaga",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Candidatura_Vagas_tb_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "tb_Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Idioma_Vaga",
                columns: table => new
                {
                    IdIdioma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdVaga = table.Column<int>(nullable: false),
                    NivelIdioma = table.Column<string>(nullable: true),
                    NomeIdioma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Idioma_Vaga", x => x.IdIdioma);
                    table.ForeignKey(
                        name: "FK_tb_Idioma_Vaga_tb_Vagas_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "tb_Vagas",
                        principalColumn: "IdVaga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Candidato_IdCurriculo",
                table: "tb_Candidato",
                column: "IdCurriculo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Candidato_IdUsuario",
                table: "tb_Candidato",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Candidatura_Vagas_IdVaga",
                table: "tb_Candidatura_Vagas",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Candidatura_Vagas_UsuarioIdUsuario",
                table: "tb_Candidatura_Vagas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Gestor_IdCurriculo",
                table: "tb_Gestor",
                column: "IdCurriculo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Gestor_IdUsuario",
                table: "tb_Gestor",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Headhunter_IdUsuario",
                table: "tb_Headhunter",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Idioma_Candidato_IdCandidato",
                table: "tb_Idioma_Candidato",
                column: "IdCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Idioma_Gestor_IdGestor",
                table: "tb_Idioma_Gestor",
                column: "IdGestor");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Idioma_Vaga_IdVaga",
                table: "tb_Idioma_Vaga",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Vagas_IdHeadhunter",
                table: "tb_Vagas",
                column: "IdHeadhunter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Candidatura_Vagas");

            migrationBuilder.DropTable(
                name: "tb_Idioma_Candidato");

            migrationBuilder.DropTable(
                name: "tb_Idioma_Gestor");

            migrationBuilder.DropTable(
                name: "tb_Idioma_Vaga");

            migrationBuilder.DropTable(
                name: "tb_Candidato");

            migrationBuilder.DropTable(
                name: "tb_Gestor");

            migrationBuilder.DropTable(
                name: "tb_Vagas");

            migrationBuilder.DropTable(
                name: "tb_Curriculo");

            migrationBuilder.DropTable(
                name: "tb_Headhunter");

            migrationBuilder.DropTable(
                name: "tb_Usuario");
        }
    }
}
