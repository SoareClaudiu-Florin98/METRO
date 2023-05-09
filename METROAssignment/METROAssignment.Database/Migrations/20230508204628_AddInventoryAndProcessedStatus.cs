using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace METROAssignment.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryAndProcessedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                schema: "dbo",
                table: "Payment",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Inventory",
                schema: "dbo",
                table: "Article",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProcessed",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Inventory",
                schema: "dbo",
                table: "Article");
        }
    }
}
