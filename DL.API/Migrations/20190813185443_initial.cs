using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DL.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabinTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ShipId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabinTypes_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 119055, "MSC Cruises" },
                    { 131168, "Celebrity Cruises" },
                    { 93195, "Royal Caribbean" }
                });

            migrationBuilder.InsertData(
                table: "Ports",
                columns: new[] { "Id", "Country", "CountryCode", "Title" },
                values: new object[,]
                {
                    { 868857, "Norway", "NO", "Sandefjord, Norway" },
                    { 332439, "France", "FR", "St. Florent, Corsica, France" },
                    { 15118272, "Maldives", "MV", "Ari Atoll, Maldives" }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "CompanyId", "Title" },
                values: new object[,]
                {
                    { 119075, 119055, "MSC Fantasia" },
                    { 119463, 119055, "MSC Splendida" }
                });

            migrationBuilder.InsertData(
                table: "CabinTypes",
                columns: new[] { "Id", "ShipId", "Title" },
                values: new object[,]
                {
                    { 119375, 119075, "Balcony Cabin: Fantastica B2" },
                    { 119395, 119075, "Suite: Aurea S3" },
                    { 843466, 119075, "Suite: Aurea SP3" },
                    { 119538, 119463, "Suite: Executive and Family YC2" },
                    { 119542, 119463, "Balcony Cabin: Aurea B3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabinTypes_ShipId",
                table: "CabinTypes",
                column: "ShipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinTypes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
