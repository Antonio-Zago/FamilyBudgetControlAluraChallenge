using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyBudgetControlAluraChallenge.Migrations
{
    public partial class AddTableCategoriaDespesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaDespesaId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoriaDespesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaDespesas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CategoriaDespesaId",
                table: "Despesas",
                column: "CategoriaDespesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_CategoriaDespesas_CategoriaDespesaId",
                table: "Despesas",
                column: "CategoriaDespesaId",
                principalTable: "CategoriaDespesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_CategoriaDespesas_CategoriaDespesaId",
                table: "Despesas");

            migrationBuilder.DropTable(
                name: "CategoriaDespesas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_CategoriaDespesaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "CategoriaDespesaId",
                table: "Despesas");
        }
    }
}
