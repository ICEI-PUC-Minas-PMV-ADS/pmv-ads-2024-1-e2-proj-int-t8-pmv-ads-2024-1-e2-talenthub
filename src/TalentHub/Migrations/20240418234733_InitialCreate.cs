using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentHub.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    IdProjeto = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeProjeto = table.Column<string>(type: "TEXT", nullable: false),
                    UrlRepositorio = table.Column<string>(type: "TEXT", nullable: false),
                    UrlAplicacao = table.Column<string>(type: "TEXT", nullable: false),
                    Integrantes = table.Column<string>(type: "TEXT", nullable: false),
                    QtdVisualizacoes = table.Column<int>(nullable: false),
                    NotaMedia = table.Column<float>(nullable: false),
                    UsuarioIdUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.IdProjeto);
                    table.ForeignKey(
                        name: "FK_Projetos_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Anotacoes",
                columns: table => new
                {
                    IdAnotacao = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioIdUsuario = table.Column<int>(nullable: false),
                    IdProjeto = table.Column<int>(nullable: false),
                    ProjetoIdProjeto = table.Column<int>(nullable: false),
                    TextoAnotacao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotacoes", x => x.IdAnotacao);
                    table.ForeignKey(
                        name: "FK_Anotacoes_Projetos_ProjetoIdProjeto",
                        column: x => x.ProjetoIdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "IdProjeto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anotacoes_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioIdUsuario = table.Column<int>(nullable: false),
                    IdProjeto = table.Column<int>(nullable: false),
                    ProjetoIdProjeto = table.Column<int>(nullable: false),
                    Nota = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Projetos_ProjetoIdProjeto",
                        column: x => x.ProjetoIdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "IdProjeto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anotacoes_ProjetoIdProjeto",
                table: "Anotacoes",
                column: "ProjetoIdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Anotacoes_UsuarioIdUsuario",
                table: "Anotacoes",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ProjetoIdProjeto",
                table: "Avaliacoes",
                column: "ProjetoIdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsuarioIdUsuario",
                table: "Avaliacoes",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_UsuarioIdUsuario",
                table: "Projetos",
                column: "UsuarioIdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anotacoes");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}