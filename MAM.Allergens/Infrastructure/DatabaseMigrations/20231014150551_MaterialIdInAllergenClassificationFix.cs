using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAM.Allergens.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class MaterialIdInAllergenClassificationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialId",
                table: "AllergenClassifications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "AllergenClassifications");
        }
    }
}
