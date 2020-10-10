using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaDeRegistro.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", nullable: true),
                    Senha = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moedas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    CaixaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moedas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moedas_Caixas_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sangrias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(nullable: false),
                    MoedaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    CaixaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sangrias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sangrias_Caixas_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sangrias_Moedas_MoedaId",
                        column: x => x.MoedaId,
                        principalTable: "Moedas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sangrias_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moedas_CaixaId",
                table: "Moedas",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sangrias_CaixaId",
                table: "Sangrias",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sangrias_MoedaId",
                table: "Sangrias",
                column: "MoedaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sangrias_UsuarioId",
                table: "Sangrias",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sangrias");

            migrationBuilder.DropTable(
                name: "Moedas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Caixas");
        }
    }
}
