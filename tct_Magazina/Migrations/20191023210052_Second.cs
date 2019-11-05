using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tct_Magazina.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Managers_ManagerId",
                table: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Sectors_ManagerId",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Sectors");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Warehouses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Sectors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Managers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DefaultValue",
                table: "Managers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "Managers");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Sectors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_ManagerId",
                table: "Sectors",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Managers_ManagerId",
                table: "Sectors",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
