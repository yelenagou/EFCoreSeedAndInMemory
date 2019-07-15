using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WiredBrainCoffeeShops.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrewerTypes",
                columns: table => new
                {
                    BrewerTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Recipe_WaterTemperatureF = table.Column<int>(nullable: false),
                    Recipe_GrindSize = table.Column<int>(nullable: false),
                    Recipe_GrindOunces = table.Column<int>(nullable: false),
                    Recipe_WaterOunces = table.Column<int>(nullable: false),
                    Recipe_BrewMinutes = table.Column<int>(nullable: false),
                    Recipe_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewerTypes", x => x.BrewerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    OpenTime = table.Column<string>(nullable: true),
                    CloseTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<Guid>(nullable: true),
                    BrewerTypeId = table.Column<int>(nullable: false),
                    Acquired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BrewerTypes",
                columns: new[] { "BrewerTypeId", "Description", "Recipe_BrewMinutes", "Recipe_Description", "Recipe_GrindOunces", "Recipe_GrindSize", "Recipe_WaterOunces", "Recipe_WaterTemperatureF" },
                values: new object[,]
                {
                    { 1, "Glass Hourglass Drip", 3, "So good!", 2, 2, 9, 130 },
                    { 2, "Hand Press", 1, "Love a hand pressed coffee!", 2, 2, 9, 130 },
                    { 3, "Cold Brew", 60, "Cold brew is worth the wait!", 2, 2, 9, 130 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { new Guid("01963dee-44f8-42f8-8f60-42e2ce8cf13d"), "4PM", "6AM", "999 Main Street" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "Acquired", "BrewerTypeId", "LocationId" },
                values: new object[] { 2, new DateTime(2018, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "Acquired", "BrewerTypeId", "LocationId" },
                values: new object[] { 1, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("01963dee-44f8-42f8-8f60-42e2ce8cf13d") });

            migrationBuilder.CreateIndex(
                name: "IX_Units_LocationId",
                table: "Units",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewerTypes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
