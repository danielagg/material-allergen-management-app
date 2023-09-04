using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAM.Allergens.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class MaterialCodeAsValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identification",
                schema: "allergens",
                table: "Materials",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Code_Value",
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
                name: "Code_Value",
                schema: "allergens",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "allergens",
                table: "Materials",
                newName: "Identification");
        }
    }
}
