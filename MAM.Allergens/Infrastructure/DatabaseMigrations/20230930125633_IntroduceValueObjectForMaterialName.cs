using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAM.Allergens.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class IntroduceValueObjectForMaterialName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "allergens",
                table: "Materials",
                newName: "Name_ShortName");

            migrationBuilder.AddColumn<string>(
                name: "Name_FullName",
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
                name: "Name_FullName",
                schema: "allergens",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "Name_ShortName",
                schema: "allergens",
                table: "Materials",
                newName: "Name");
        }
    }
}
