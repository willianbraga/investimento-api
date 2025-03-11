using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Investimento.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agencia = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    NumeroConta = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DAC = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investimentos_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "Agencia", "DAC", "NumeroConta" },
                values: new object[,]
                {
                    { 1, "0001", "123", "123456" },
                    { 2, "0002", "456", "654321" },
                    { 3, "0003", "789", "567890" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_ContaId",
                table: "Investimentos",
                column: "ContaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
