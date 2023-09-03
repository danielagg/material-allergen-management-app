using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MAM.Allergens.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class AddNameToMaterialTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "2cb9838e-8f77-4217-8558-55874ceef8cd");

            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "6b8898cc-1ec3-4d7d-bd1c-e4d3890056ed");

            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "748ca8d1-9eb3-430b-bea5-1e4ddf585819");

            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "9be1b154-8916-4ee7-9878-c00494fb01f1");

            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "c61e1dc8-c257-4796-8423-7815051e0ca8");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "allergens",
                table: "MaterialTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "2cb9838e-8f77-4217-8558-55874ceef8ce");

            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "6b8898cc-1ec3-4d7d-bd1c-e4d3890056ee");

            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "748ca8d1-9eb3-430b-bea5-1e4ddf585815");

            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "9be1b154-8916-4ee7-9878-c00494fb01f2");

            migrationBuilder.DeleteData(
                schema: "allergens",
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: "c61e1dc8-c257-4796-8423-7815051e0ca6");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "allergens",
                table: "MaterialTypes");

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
        }
    }
}
