using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchFlix.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id_Filme = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sinopse = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Poster_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnoLancamento = table.Column<int>(type: "int", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id_Filme);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id_Genero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id_Genero);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Filme_Genero",
                columns: table => new
                {
                    Id_Filme = table.Column<int>(type: "int", nullable: false),
                    Id_Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme_Genero", x => new { x.Id_Filme, x.Id_Genero });
                    table.ForeignKey(
                        name: "FK_Filme_Genero_Filme_Id_Filme",
                        column: x => x.Id_Filme,
                        principalTable: "Filme",
                        principalColumn: "Id_Filme",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filme_Genero_Genero_Id_Genero",
                        column: x => x.Id_Genero,
                        principalTable: "Genero",
                        principalColumn: "Id_Genero",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grupo_Sessao",
                columns: table => new
                {
                    Id_Grupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome_Grupo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoConvite = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriaçao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id_Usuario_Criador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo_Sessao", x => x.Id_Grupo);
                    table.ForeignKey(
                        name: "FK_Grupo_Sessao_Usuario_Id_Usuario_Criador",
                        column: x => x.Id_Usuario_Criador,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Membro_Grupo",
                columns: table => new
                {
                    Id_Membro_Grupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Grupo = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Papel = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro_Grupo", x => x.Id_Membro_Grupo);
                    table.ForeignKey(
                        name: "FK_Membro_Grupo_Grupo_Sessao_Id_Grupo",
                        column: x => x.Id_Grupo,
                        principalTable: "Grupo_Sessao",
                        principalColumn: "Id_Grupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membro_Grupo_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    Id_Sessao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Grupo = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.Id_Sessao);
                    table.ForeignKey(
                        name: "FK_Sessao_Grupo_Sessao_Id_Grupo",
                        column: x => x.Id_Grupo,
                        principalTable: "Grupo_Sessao",
                        principalColumn: "Id_Grupo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    id_match = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Sessao = table.Column<int>(type: "int", nullable: false),
                    Id_Filme = table.Column<int>(type: "int", nullable: false),
                    Total_Likes = table.Column<int>(type: "int", nullable: false),
                    DataMacth = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.id_match);
                    table.ForeignKey(
                        name: "FK_Match_Filme_Id_Filme",
                        column: x => x.Id_Filme,
                        principalTable: "Filme",
                        principalColumn: "Id_Filme",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Sessao_Id_Sessao",
                        column: x => x.Id_Sessao,
                        principalTable: "Sessao",
                        principalColumn: "Id_Sessao",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sessao_Filme",
                columns: table => new
                {
                    Id_Sessao_Filme = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Sessao = table.Column<int>(type: "int", nullable: false),
                    Id_Filme = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao_Filme", x => x.Id_Sessao_Filme);
                    table.ForeignKey(
                        name: "FK_Sessao_Filme_Filme_Id_Filme",
                        column: x => x.Id_Filme,
                        principalTable: "Filme",
                        principalColumn: "Id_Filme",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessao_Filme_Sessao_Id_Sessao",
                        column: x => x.Id_Sessao,
                        principalTable: "Sessao",
                        principalColumn: "Id_Sessao",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id_Avaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Sessao_Filme = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    like = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id_Avaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Sessao_Filme_Id_Sessao_Filme",
                        column: x => x.Id_Sessao_Filme,
                        principalTable: "Sessao_Filme",
                        principalColumn: "Id_Sessao_Filme",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_Id_Sessao_Filme",
                table: "Avaliacao",
                column: "Id_Sessao_Filme");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_Id_Usuario",
                table: "Avaliacao",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_Genero_Id_Genero",
                table: "Filme_Genero",
                column: "Id_Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_Sessao_Id_Usuario_Criador",
                table: "Grupo_Sessao",
                column: "Id_Usuario_Criador");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Id_Filme",
                table: "Match",
                column: "Id_Filme");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Id_Sessao",
                table: "Match",
                column: "Id_Sessao");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_Grupo_Id_Grupo",
                table: "Membro_Grupo",
                column: "Id_Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_Grupo_Id_Usuario",
                table: "Membro_Grupo",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_Id_Grupo",
                table: "Sessao",
                column: "Id_Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_Filme_Id_Filme",
                table: "Sessao_Filme",
                column: "Id_Filme");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_Filme_Id_Sessao",
                table: "Sessao_Filme",
                column: "Id_Sessao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Filme_Genero");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Membro_Grupo");

            migrationBuilder.DropTable(
                name: "Sessao_Filme");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Sessao");

            migrationBuilder.DropTable(
                name: "Grupo_Sessao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
