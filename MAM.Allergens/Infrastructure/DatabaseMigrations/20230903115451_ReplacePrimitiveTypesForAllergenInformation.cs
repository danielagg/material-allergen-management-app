using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAM.Allergens.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class ReplacePrimitiveTypesForAllergenInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergenByCrossContamination",
                schema: "allergens",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "AllergenByNature",
                schema: "allergens",
                table: "Materials");

            migrationBuilder.AddColumn<string>(
                name: "AllergensByCrossContamination_Allergens",
                schema: "allergens",
                table: "Materials",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AllergensByNature_Allergens",
                schema: "allergens",
                table: "Materials",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergensByCrossContamination_Allergens",
                schema: "allergens",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "AllergensByNature_Allergens",
                schema: "allergens",
                table: "Materials");

            migrationBuilder.AddColumn<bool>(
                name: "AllergenByCrossContamination",
                schema: "allergens",
                table: "Materials",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllergenByNature",
                schema: "allergens",
                table: "Materials",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
