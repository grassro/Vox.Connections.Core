using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VoxConnections.Convidados.Core.Migrations
{
    public partial class _Initial : Migration
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
                name: "tb_Idioma_Vaga",
                columns: table => new
                {
                    IdIdioma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoIdioma = table.Column<int>(nullable: false),
                    NivelIdioma = table.Column<string>(nullable: true),
                    NomeIdioma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Idioma_Vaga", x => x.IdIdioma);
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
                    AreaInteresse = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Empregado = table.Column<bool>(nullable: false),
                    Esfera = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    IdCurriculo = table.Column<int>(nullable: false),
                    IdIdioma = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
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
                    AreaInteresse = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Empregado = table.Column<bool>(nullable: false),
                    Esfera = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    IdCurriculo = table.Column<int>(nullable: false),
                    IdIdioma = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
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
                name: "tb_Vagas",
                columns: table => new
                {
                    IdVaga = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaAtuacao = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Cidade = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    HeadhunterIdHeadhunter = table.Column<int>(nullable: true),
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
                        name: "FK_tb_Vagas_tb_Headhunter_HeadhunterIdHeadhunter",
                        column: x => x.HeadhunterIdHeadhunter,
                        principalTable: "tb_Headhunter",
                        principalColumn: "IdHeadhunter",
                        onDelete: ReferentialAction.Restrict);
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
                name: "tb_Idioma",
                columns: table => new
                {
                    IdIdioma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidatoIdCandidato = table.Column<int>(nullable: true),
                    CodigoIdioma = table.Column<int>(nullable: false),
                    GestorIdGestor = table.Column<int>(nullable: true),
                    NivelIdioma = table.Column<string>(nullable: true),
                    NomeIdioma = table.Column<string>(nullable: true),
                    VagasIdVaga = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Idioma", x => x.IdIdioma);
                    table.ForeignKey(
                        name: "FK_tb_Idioma_tb_Candidato_CandidatoIdCandidato",
                        column: x => x.CandidatoIdCandidato,
                        principalTable: "tb_Candidato",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Idioma_tb_Gestor_GestorIdGestor",
                        column: x => x.GestorIdGestor,
                        principalTable: "tb_Gestor",
                        principalColumn: "IdGestor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_Idioma_tb_Vagas_VagasIdVaga",
                        column: x => x.VagasIdVaga,
                        principalTable: "tb_Vagas",
                        principalColumn: "IdVaga",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_tb_Idioma_CandidatoIdCandidato",
                table: "tb_Idioma",
                column: "CandidatoIdCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Idioma_GestorIdGestor",
                table: "tb_Idioma",
                column: "GestorIdGestor");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Idioma_VagasIdVaga",
                table: "tb_Idioma",
                column: "VagasIdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Vagas_HeadhunterIdHeadhunter",
                table: "tb_Vagas",
                column: "HeadhunterIdHeadhunter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Candidatura_Vagas");

            migrationBuilder.DropTable(
                name: "tb_Idioma");

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
