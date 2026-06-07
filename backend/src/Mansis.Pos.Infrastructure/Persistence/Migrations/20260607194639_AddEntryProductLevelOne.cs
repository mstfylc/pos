using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mansis.Pos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEntryProductLevelOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_entry",
                schema: "pos",
                table: "order_products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "entry_tracking_mode",
                schema: "pos",
                table: "branches",
                type: "text",
                nullable: false,
                defaultValue: "Manual");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_entry",
                schema: "pos",
                table: "order_products");

            migrationBuilder.DropColumn(
                name: "entry_tracking_mode",
                schema: "pos",
                table: "branches");
        }
    }
}
