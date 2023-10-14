using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAM.Allergens.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class RemoveInventoryRelatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock_CurrentAvailableStock",
                schema: "allergens",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Stock_UnitOfMeasure_Code",
                schema: "allergens",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Stock_UnitOfMeasure_Name",
                schema: "allergens",
                table: "Materials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Stock_CurrentAvailableStock",
                schema: "allergens",
                table: "Materials",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Stock_UnitOfMeasure_Code",
                schema: "allergens",
                table: "Materials",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Stock_UnitOfMeasure_Name",
                schema: "allergens",
                table: "Materials",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
