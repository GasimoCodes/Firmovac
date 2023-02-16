using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Firmovac.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColumnDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isHidden = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirmaEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmaEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirmaSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmaSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OborId = table.Column<int>(type: "int", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firms_FirmaSources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "FirmaSources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Firms_Obors_OborId",
                        column: x => x.OborId,
                        principalTable: "Obors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirmaContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmaContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirmaContacts_Firms_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firms",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "FirmaSources",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Praxe žáků" },
                    { 3, "Prac. Nab. z portálu" }
                });

            migrationBuilder.InsertData(
                table: "Obors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "ELE" },
                    { 3, "AM" },
                    { 4, "N/A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirmaContacts_FirmaId",
                table: "FirmaContacts",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_FirmaEvents_Name",
                table: "FirmaEvents",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_Name",
                table: "Firms",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_OborId",
                table: "Firms",
                column: "OborId");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_SourceId",
                table: "Firms",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnDefinitions");

            migrationBuilder.DropTable(
                name: "FirmaContacts");

            migrationBuilder.DropTable(
                name: "FirmaEvents");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "FirmaSources");

            migrationBuilder.DropTable(
                name: "Obors");
        }
    }
}
