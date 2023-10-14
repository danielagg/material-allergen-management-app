using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAM.Inventory.Infrastructure.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inventory");

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UnitOfMeasure_Code = table.Column<string>(type: "TEXT", nullable: false),
                    UnitOfMeasure_Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentAvailableStock = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "inventory");
        }
    }
}
