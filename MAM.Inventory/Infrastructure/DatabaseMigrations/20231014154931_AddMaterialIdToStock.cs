using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAM.Inventory.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class AddMaterialIdToStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Stocks",
                schema: "inventory",
                newName: "Stocks");

            migrationBuilder.AddColumn<string>(
                name: "MaterialId",
                table: "Stocks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Stocks");

            migrationBuilder.EnsureSchema(
                name: "inventory");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stocks",
                newSchema: "inventory");
        }
    }
}
