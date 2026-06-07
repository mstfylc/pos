using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mansis.Pos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignMaxTotalDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "max_total_discount",
                schema: "pos",
                table: "campaigns",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max_total_discount",
                schema: "pos",
                table: "campaigns");
        }
    }
}
