using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCRUDApp.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_Pessoa_CargoId",
                table: "tb_Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Pessoa_CargoId",
                table: "tb_Pessoa",
                column: "CargoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_Pessoa_CargoId",
                table: "tb_Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Pessoa_CargoId",
                table: "tb_Pessoa",
                column: "CargoId",
                unique: true);
        }
    }
}
