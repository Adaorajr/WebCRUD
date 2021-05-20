using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCRUDApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Cargo", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "tb_Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SobreNome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Pessoa_tb_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "tb_Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Pessoa_CargoId",
                table: "tb_Pessoa",
                column: "CargoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Pessoa");

            migrationBuilder.DropTable(
                name: "tb_Cargo");
        }
    }
}
