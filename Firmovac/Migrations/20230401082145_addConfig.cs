using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firmovac.Migrations
{
    /// <inheritdoc />
    public partial class addConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Key = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Key);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Key", "Value" },
                values: new object[] { "SMTP_Addr", "127.0.0.1" });

            migrationBuilder.CreateIndex(
                name: "IX_Config_Key",
                table: "Config",
                column: "Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");
        }
    }
}
