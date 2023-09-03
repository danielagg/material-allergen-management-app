using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaterialAllergenManagementApp.Allergens.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class RenameMaterialAggregateAndCreateMaterialTypeAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialAllergens",
                schema: "allergens");

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                schema: "allergens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicableFor = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    Identification = table.Column<string>(type: "TEXT", nullable: false),
                    TypeId = table.Column<string>(type: "TEXT", nullable: false),
                    AllergenByNature = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllergenByCrossContamination = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                columns: new[] { "Id", "ApplicableFor", "CreatedOn" },
                values: new object[,]
                {
                    { "2cb9838e-8f77-4217-8558-55874ceef8cd", "PackagingMaterial", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6b8898cc-1ec3-4d7d-bd1c-e4d3890056ed", "FinishedGood", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "748ca8d1-9eb3-430b-bea5-1e4ddf585819", "RawMaterial;FinishedGood", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "9be1b154-8916-4ee7-9878-c00494fb01f1", "RawMaterial;FinishedGood;PackagingMaterial", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c61e1dc8-c257-4796-8423-7815051e0ca8", "PackagingMaterial", new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_TypeId",
                schema: "allergens",
                table: "Materials",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials",
                schema: "allergens");

            migrationBuilder.DropTable(
                name: "MaterialTypes",
                schema: "allergens");

            migrationBuilder.CreateTable(
                name: "MaterialAllergens",
                schema: "allergens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AllergenByCrossContamination = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllergenByNature = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Material = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialAllergens", x => x.Id);
                });
        }
    }
}
