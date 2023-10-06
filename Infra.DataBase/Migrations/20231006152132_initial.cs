using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advogados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oab = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advogados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessosJudiciais",
                columns: table => new
                {
                    NumeroProcesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tema = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ValorCausa = table.Column<double>(type: "float(8)", precision: 8, scale: 2, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    AdvogadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessosJudiciais", x => x.NumeroProcesso);
                    table.ForeignKey(
                        name: "FK_ProcessosJudiciais_Advogados_AdvogadoId",
                        column: x => x.AdvogadoId,
                        principalTable: "Advogados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessosJudiciais_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Caminho = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroProcesso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_ProcessosJudiciais_NumeroProcesso",
                        column: x => x.NumeroProcesso,
                        principalTable: "ProcessosJudiciais",
                        principalColumn: "NumeroProcesso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advogados_Cpf",
                table: "Advogados",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advogados_Oab",
                table: "Advogados",
                column: "Oab",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cpf",
                table: "Clientes",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_NumeroProcesso",
                table: "Documentos",
                column: "NumeroProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessosJudiciais_AdvogadoId",
                table: "ProcessosJudiciais",
                column: "AdvogadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessosJudiciais_ClienteId",
                table: "ProcessosJudiciais",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "ProcessosJudiciais");

            migrationBuilder.DropTable(
                name: "Advogados");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
