using Microsoft.EntityFrameworkCore.Migrations;

namespace tct_Magazina.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Sectors_SectorId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_SectorId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Warehouses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_SectorId",
                table: "Warehouses",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Sectors_SectorId",
                table: "Warehouses",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
