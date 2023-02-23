using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firmovac.Migrations
{
    /// <inheritdoc />
    public partial class propertyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JsonColumns",
                table: "Firms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FirmaId",
                table: "FirmaEvents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FirmaEvents_FirmaId",
                table: "FirmaEvents",
                column: "FirmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirmaEvents_Firms_FirmaId",
                table: "FirmaEvents",
                column: "FirmaId",
                principalTable: "Firms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirmaEvents_Firms_FirmaId",
                table: "FirmaEvents");

            migrationBuilder.DropIndex(
                name: "IX_FirmaEvents_FirmaId",
                table: "FirmaEvents");

            migrationBuilder.DropColumn(
                name: "JsonColumns",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "FirmaEvents");
        }
    }
}
