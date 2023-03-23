using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firmovac.Migrations
{
    /// <inheritdoc />
    public partial class addedFirmaActve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAktivni",
                table: "Firms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAktivni",
                table: "Firms");
        }
    }
}
