using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VoxConnections.Convidados.Core.Migrations
{
    public partial class _Initial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Vagas_tb_Headhunter_HeadhunterIdHeadhunter",
                table: "tb_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_tb_Vagas_HeadhunterIdHeadhunter",
                table: "tb_Vagas");

            migrationBuilder.DropColumn(
                name: "HeadhunterIdHeadhunter",
                table: "tb_Vagas");

            migrationBuilder.AddColumn<int>(
                name: "IdHeadhunter",
                table: "tb_Vagas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Vagas_IdHeadhunter",
                table: "tb_Vagas",
                column: "IdHeadhunter");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Vagas_tb_Headhunter_IdHeadhunter",
                table: "tb_Vagas",
                column: "IdHeadhunter",
                principalTable: "tb_Headhunter",
                principalColumn: "IdHeadhunter",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Vagas_tb_Headhunter_IdHeadhunter",
                table: "tb_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_tb_Vagas_IdHeadhunter",
                table: "tb_Vagas");

            migrationBuilder.DropColumn(
                name: "IdHeadhunter",
                table: "tb_Vagas");

            migrationBuilder.AddColumn<int>(
                name: "HeadhunterIdHeadhunter",
                table: "tb_Vagas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Vagas_HeadhunterIdHeadhunter",
                table: "tb_Vagas",
                column: "HeadhunterIdHeadhunter");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Vagas_tb_Headhunter_HeadhunterIdHeadhunter",
                table: "tb_Vagas",
                column: "HeadhunterIdHeadhunter",
                principalTable: "tb_Headhunter",
                principalColumn: "IdHeadhunter",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
