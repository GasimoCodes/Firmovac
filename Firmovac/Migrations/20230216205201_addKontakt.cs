using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Firmovac.Migrations
{
    /// <inheritdoc />
    public partial class addKontakt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FirmaContacts",
                columns: new[] { "Id", "Email", "FirmaId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "nemec@spsejecna.cz", null, "N. Němec", null },
                    { 2, null, null, "Večirka", "777022400" },
                    { 3, null, null, "Velký J.", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FirmaContacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FirmaContacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FirmaContacts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
