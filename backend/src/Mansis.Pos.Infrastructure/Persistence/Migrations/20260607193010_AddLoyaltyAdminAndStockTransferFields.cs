using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mansis.Pos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLoyaltyAdminAndStockTransferFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cancel_reason",
                schema: "pos",
                table: "store_product_transfers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "cancelled_by_id",
                schema: "pos",
                table: "store_product_transfers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "cancelled_time",
                schema: "pos",
                table: "store_product_transfers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image",
                schema: "pos",
                table: "rewards",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "benefits",
                schema: "pos",
                table: "loyalty_tiers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "stamp_cards",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    required_stamps = table.Column<int>(type: "integer", nullable: false),
                    reward_id = table.Column<Guid>(type: "uuid", nullable: true),
                    starts_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ends_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stamp_cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_stamp_cards_rewards_reward_id",
                        column: x => x.reward_id,
                        principalSchema: "pos",
                        principalTable: "rewards",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfers_cancelled_by_id",
                schema: "pos",
                table: "store_product_transfers",
                column: "cancelled_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_stamp_cards_company_id_active",
                schema: "pos",
                table: "stamp_cards",
                columns: new[] { "company_id", "active" });

            migrationBuilder.CreateIndex(
                name: "IX_stamp_cards_reward_id",
                schema: "pos",
                table: "stamp_cards",
                column: "reward_id");

            migrationBuilder.AddForeignKey(
                name: "FK_store_product_transfers_users_cancelled_by_id",
                schema: "pos",
                table: "store_product_transfers",
                column: "cancelled_by_id",
                principalSchema: "pos",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_store_product_transfers_users_cancelled_by_id",
                schema: "pos",
                table: "store_product_transfers");

            migrationBuilder.DropTable(
                name: "stamp_cards",
                schema: "pos");

            migrationBuilder.DropIndex(
                name: "IX_store_product_transfers_cancelled_by_id",
                schema: "pos",
                table: "store_product_transfers");

            migrationBuilder.DropColumn(
                name: "cancel_reason",
                schema: "pos",
                table: "store_product_transfers");

            migrationBuilder.DropColumn(
                name: "cancelled_by_id",
                schema: "pos",
                table: "store_product_transfers");

            migrationBuilder.DropColumn(
                name: "cancelled_time",
                schema: "pos",
                table: "store_product_transfers");

            migrationBuilder.DropColumn(
                name: "image",
                schema: "pos",
                table: "rewards");

            migrationBuilder.DropColumn(
                name: "benefits",
                schema: "pos",
                table: "loyalty_tiers");
        }
    }
}
