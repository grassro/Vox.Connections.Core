using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VoxConnections.Convidados.Core.Migrations
{
    public partial class _19_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAreaExecutiva",
                table: "tb_Gestor");

            migrationBuilder.DropColumn(
                name: "isEsfera",
                table: "tb_Gestor");

            migrationBuilder.DropColumn(
                name: "isLink",
                table: "tb_Gestor");

            migrationBuilder.DropColumn(
                name: "isAreaExecutiva",
                table: "tb_Candidato");

            migrationBuilder.DropColumn(
                name: "isEsfera",
                table: "tb_Candidato");

            migrationBuilder.DropColumn(
                name: "isLink",
                table: "tb_Candidato");

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "tb_Gestor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "tb_Candidato",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "tb_Gestor");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "tb_Candidato");

            migrationBuilder.AddColumn<bool>(
                name: "isAreaExecutiva",
                table: "tb_Gestor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isEsfera",
                table: "tb_Gestor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLink",
                table: "tb_Gestor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isAreaExecutiva",
                table: "tb_Candidato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isEsfera",
                table: "tb_Candidato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLink",
                table: "tb_Candidato",
                nullable: false,
                defaultValue: false);
        }
    }
}
