using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VoxConnections.Convidados.Core.Migrations
{
    public partial class _19_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaExecutiva",
                table: "tb_Gestor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Formacao",
                table: "tb_Gestor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "tb_Gestor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "tb_Gestor",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "AreaExecutiva",
                table: "tb_Candidato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Formacao",
                table: "tb_Candidato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "tb_Candidato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "tb_Candidato",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaExecutiva",
                table: "tb_Gestor");

            migrationBuilder.DropColumn(
                name: "Formacao",
                table: "tb_Gestor");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "tb_Gestor");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "tb_Gestor");

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
                name: "AreaExecutiva",
                table: "tb_Candidato");

            migrationBuilder.DropColumn(
                name: "Formacao",
                table: "tb_Candidato");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "tb_Candidato");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "tb_Candidato");

            migrationBuilder.DropColumn(
                name: "isAreaExecutiva",
                table: "tb_Candidato");

            migrationBuilder.DropColumn(
                name: "isEsfera",
                table: "tb_Candidato");

            migrationBuilder.DropColumn(
                name: "isLink",
                table: "tb_Candidato");
        }
    }
}
