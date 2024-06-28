using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentHub.Migrations
{
    public partial class UpdateForeignKeyConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotacoes_Projetos_ProjetoIdProjeto",
                table: "Anotacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotacoes_Usuarios_UsuarioIdUsuario",
                table: "Anotacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Projetos_ProjetoIdProjeto",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Usuarios_UsuarioIdUsuario",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_ProjetoIdProjeto",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_UsuarioIdUsuario",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Anotacoes_ProjetoIdProjeto",
                table: "Anotacoes");

            migrationBuilder.DropIndex(
                name: "IX_Anotacoes_UsuarioIdUsuario",
                table: "Anotacoes");

            migrationBuilder.DropColumn(
                name: "ProjetoIdProjeto",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "ProjetoIdProjeto",
                table: "Anotacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Anotacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_IdProjeto",
                table: "Avaliacoes",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_IdUsuario",
                table: "Avaliacoes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Anotacoes_IdProjeto",
                table: "Anotacoes",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Anotacoes_IdUsuario",
                table: "Anotacoes",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotacoes_Projetos_IdProjeto",
                table: "Anotacoes",
                column: "IdProjeto",
                principalTable: "Projetos",
                principalColumn: "IdProjeto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anotacoes_Usuarios_IdUsuario",
                table: "Anotacoes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Projetos_IdProjeto",
                table: "Avaliacoes",
                column: "IdProjeto",
                principalTable: "Projetos",
                principalColumn: "IdProjeto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Usuarios_IdUsuario",
                table: "Avaliacoes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anotacoes_Projetos_IdProjeto",
                table: "Anotacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Anotacoes_Usuarios_IdUsuario",
                table: "Anotacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Projetos_IdProjeto",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Usuarios_IdUsuario",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_IdProjeto",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_IdUsuario",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Anotacoes_IdProjeto",
                table: "Anotacoes");

            migrationBuilder.DropIndex(
                name: "IX_Anotacoes_IdUsuario",
                table: "Anotacoes");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoIdProjeto",
                table: "Avaliacoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Avaliacoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoIdProjeto",
                table: "Anotacoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Anotacoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ProjetoIdProjeto",
                table: "Avaliacoes",
                column: "ProjetoIdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsuarioIdUsuario",
                table: "Avaliacoes",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Anotacoes_ProjetoIdProjeto",
                table: "Anotacoes",
                column: "ProjetoIdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Anotacoes_UsuarioIdUsuario",
                table: "Anotacoes",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Anotacoes_Projetos_ProjetoIdProjeto",
                table: "Anotacoes",
                column: "ProjetoIdProjeto",
                principalTable: "Projetos",
                principalColumn: "IdProjeto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anotacoes_Usuarios_UsuarioIdUsuario",
                table: "Anotacoes",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Projetos_ProjetoIdProjeto",
                table: "Avaliacoes",
                column: "ProjetoIdProjeto",
                principalTable: "Projetos",
                principalColumn: "IdProjeto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Usuarios_UsuarioIdUsuario",
                table: "Avaliacoes",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}