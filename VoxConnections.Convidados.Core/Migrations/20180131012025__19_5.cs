using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VoxConnections.Convidados.Core.Migrations
{
    public partial class _19_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Idioma");

            migrationBuilder.DropColumn(
                name: "IdIdioma",
                table: "tb_Gestor");

            migrationBuilder.DropColumn(
                name: "IdIdioma",
                table: "tb_Candidato");

            migrationBuilder.RenameColumn(
                name: "CodigoIdioma",
                table: "tb_Idioma_Vaga",
                newName: "IdVaga");

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

            migrationBuilder.CreateIndex(
                name: "IX_tb_Idioma_Vaga_IdVaga",
                table: "tb_Idioma_Vaga",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Idioma_Candidato_IdCandidato",
                table: "tb_Idioma_Candidato",
                column: "IdCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Idioma_Gestor_IdGestor",
                table: "tb_Idioma_Gestor",
                column: "IdGestor");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Idioma_Vaga_tb_Vagas_IdVaga",
                table: "tb_Idioma_Vaga",
                column: "IdVaga",
                principalTable: "tb_Vagas",
                principalColumn: "IdVaga",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Idioma_Vaga_tb_Vagas_IdVaga",
                table: "tb_Idioma_Vaga");

            migrationBuilder.DropTable(
                name: "tb_Idioma_Candidato");

            migrationBuilder.DropTable(
                name: "tb_Idioma_Gestor");

            migrationBuilder.DropIndex(
                name: "IX_tb_Idioma_Vaga_IdVaga",
                table: "tb_Idioma_Vaga");

            migrationBuilder.RenameColumn(
                name: "IdVaga",
                table: "tb_Idioma_Vaga",
                newName: "CodigoIdioma");

            migrationBuilder.AddColumn<int>(
                name: "IdIdioma",
                table: "tb_Gestor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdIdioma",
                table: "tb_Candidato",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
