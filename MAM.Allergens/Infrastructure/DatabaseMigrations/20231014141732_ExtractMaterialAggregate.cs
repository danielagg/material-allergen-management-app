using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAM.Allergens.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class ExtractMaterialAggregate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials",
                schema: "allergens");

            migrationBuilder.DropTable(
                name: "MaterialTypes",
                schema: "allergens");

            migrationBuilder.CreateTable(
                name: "AllergenClassifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ByNatureAllergens_Allergens = table.Column<string>(type: "TEXT", nullable: false),
                    CrossContaminatingAllergens_Allergens = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenClassifications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenClassifications");

            migrationBuilder.EnsureSchema(
                name: "allergens");

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                schema: "allergens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicableFor = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                schema: "allergens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    TypeId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AllergensByCrossContamination_Allergens = table.Column<string>(type: "TEXT", nullable: false),
                    AllergensByNature_Allergens = table.Column<string>(type: "TEXT", nullable: false),
                    Code_Value = table.Column<string>(type: "TEXT", nullable: false),
                    Name_FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Name_ShortName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "allergens",
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "allergens",
                table: "MaterialTypes",
                columns: new[] { "Id", "ApplicableFor", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { "2cb9838e-8f77-4217-8558-55874ceef8ce", "PackagingMaterial", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simple Packaging Material" },
                    { "6b8898cc-1ec3-4d7d-bd1c-e4d3890056ee", "FinishedGood", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beverage" },
                    { "748ca8d1-9eb3-430b-bea5-1e4ddf585815", "RawMaterial;FinishedGood", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food" },
                    { "9be1b154-8916-4ee7-9878-c00494fb01f2", "RawMaterial;FinishedGood;PackagingMaterial", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perishable" },
                    { "c61e1dc8-c257-4796-8423-7815051e0ca6", "PackagingMaterial", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manufacturer Part" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_TypeId",
                schema: "allergens",
                table: "Materials",
                column: "TypeId");
        }
    }
}
