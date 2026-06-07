using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mansis.Pos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLoyaltyRuleEngineFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                schema: "pos",
                table: "rewards",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reward_type",
                schema: "pos",
                table: "rewards",
                type: "text",
                nullable: false,
                defaultValue: "DiscountAmount");

            migrationBuilder.AddColumn<Guid>(
                name: "order_id",
                schema: "pos",
                table: "reward_redemptions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "redemption_code",
                schema: "pos",
                table: "reward_redemptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "expires_at",
                schema: "pos",
                table: "loyalty_point_transactions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lifetime_points",
                schema: "pos",
                table: "loyalty_accounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "pos",
                table: "earn_rules",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "category_id",
                schema: "pos",
                table: "earn_rules",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "expiry_days",
                schema: "pos",
                table: "earn_rules",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "minimum_order_total",
                schema: "pos",
                table: "earn_rules",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "scope",
                schema: "pos",
                table: "earn_rules",
                type: "text",
                nullable: false,
                defaultValue: "All");

            migrationBuilder.AddColumn<string>(
                name: "campaign_type",
                schema: "pos",
                table: "campaigns",
                type: "text",
                nullable: false,
                defaultValue: "ExtraPoints");

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "pos",
                table: "campaigns",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "rule_json",
                schema: "pos",
                table: "campaigns",
                type: "text",
                nullable: false,
                defaultValue: "{}");

            migrationBuilder.AddColumn<Guid>(
                name: "target_tier_id",
                schema: "pos",
                table: "campaigns",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rewards_product_id",
                schema: "pos",
                table: "rewards",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_reward_redemptions_order_id",
                schema: "pos",
                table: "reward_redemptions",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_earn_rules_branch_id",
                schema: "pos",
                table: "earn_rules",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_earn_rules_category_id",
                schema: "pos",
                table: "earn_rules",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_campaigns_target_tier_id",
                schema: "pos",
                table: "campaigns",
                column: "target_tier_id");

            migrationBuilder.AddForeignKey(
                name: "FK_campaigns_loyalty_tiers_target_tier_id",
                schema: "pos",
                table: "campaigns",
                column: "target_tier_id",
                principalSchema: "pos",
                principalTable: "loyalty_tiers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_earn_rules_branches_branch_id",
                schema: "pos",
                table: "earn_rules",
                column: "branch_id",
                principalSchema: "pos",
                principalTable: "branches",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_earn_rules_categories_category_id",
                schema: "pos",
                table: "earn_rules",
                column: "category_id",
                principalSchema: "pos",
                principalTable: "categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_reward_redemptions_orders_order_id",
                schema: "pos",
                table: "reward_redemptions",
                column: "order_id",
                principalSchema: "pos",
                principalTable: "orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_rewards_products_product_id",
                schema: "pos",
                table: "rewards",
                column: "product_id",
                principalSchema: "pos",
                principalTable: "products",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_campaigns_loyalty_tiers_target_tier_id",
                schema: "pos",
                table: "campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_earn_rules_branches_branch_id",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropForeignKey(
                name: "FK_earn_rules_categories_category_id",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropForeignKey(
                name: "FK_reward_redemptions_orders_order_id",
                schema: "pos",
                table: "reward_redemptions");

            migrationBuilder.DropForeignKey(
                name: "FK_rewards_products_product_id",
                schema: "pos",
                table: "rewards");

            migrationBuilder.DropIndex(
                name: "IX_rewards_product_id",
                schema: "pos",
                table: "rewards");

            migrationBuilder.DropIndex(
                name: "IX_reward_redemptions_order_id",
                schema: "pos",
                table: "reward_redemptions");

            migrationBuilder.DropIndex(
                name: "IX_earn_rules_branch_id",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropIndex(
                name: "IX_earn_rules_category_id",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropIndex(
                name: "IX_campaigns_target_tier_id",
                schema: "pos",
                table: "campaigns");

            migrationBuilder.DropColumn(
                name: "product_id",
                schema: "pos",
                table: "rewards");

            migrationBuilder.DropColumn(
                name: "reward_type",
                schema: "pos",
                table: "rewards");

            migrationBuilder.DropColumn(
                name: "order_id",
                schema: "pos",
                table: "reward_redemptions");

            migrationBuilder.DropColumn(
                name: "redemption_code",
                schema: "pos",
                table: "reward_redemptions");

            migrationBuilder.DropColumn(
                name: "expires_at",
                schema: "pos",
                table: "loyalty_point_transactions");

            migrationBuilder.DropColumn(
                name: "lifetime_points",
                schema: "pos",
                table: "loyalty_accounts");

            migrationBuilder.DropColumn(
                name: "branch_id",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropColumn(
                name: "category_id",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropColumn(
                name: "expiry_days",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropColumn(
                name: "minimum_order_total",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropColumn(
                name: "scope",
                schema: "pos",
                table: "earn_rules");

            migrationBuilder.DropColumn(
                name: "campaign_type",
                schema: "pos",
                table: "campaigns");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "pos",
                table: "campaigns");

            migrationBuilder.DropColumn(
                name: "rule_json",
                schema: "pos",
                table: "campaigns");

            migrationBuilder.DropColumn(
                name: "target_tier_id",
                schema: "pos",
                table: "campaigns");
        }
    }
}
