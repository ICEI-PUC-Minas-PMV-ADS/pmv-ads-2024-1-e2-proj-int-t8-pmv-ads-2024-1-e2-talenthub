using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentHub.Migrations
{
    public partial class alteracaoProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAnotacao",
                table: "Anotacoes",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Ano",
                table: "Projetos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Projetos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoProjeto",
                table: "Projetos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PalavraChave",
                table: "Projetos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                table: "Projetos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "DescricaoProjeto",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "PalavraChave",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Projetos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Anotacoes",
                newName: "IdAnotacao");
        }
    }
}