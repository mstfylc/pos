using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mansis.Pos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderCreateUseCaseFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_store_products_store_id",
                schema: "pos",
                table: "store_products");

            migrationBuilder.DropIndex(
                name: "IX_orders_company_id",
                schema: "pos",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "idempotency_key",
                schema: "pos",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "payment_summary",
                schema: "pos",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transactions_company_id_order_id",
                schema: "pos",
                table: "wallet_transactions",
                columns: new[] { "company_id", "order_id" });

            migrationBuilder.CreateIndex(
                name: "IX_wallet_accounts_company_id_customer_id_currency",
                schema: "pos",
                table: "wallet_accounts",
                columns: new[] { "company_id", "customer_id", "currency" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_store_products_store_id_product_id",
                schema: "pos",
                table: "store_products",
                columns: new[] { "store_id", "product_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_movements_company_id_operation_id_movement_type",
                schema: "pos",
                table: "stock_movements",
                columns: new[] { "company_id", "operation_id", "movement_type" });

            migrationBuilder.CreateIndex(
                name: "IX_orders_company_id_idempotency_key",
                schema: "pos",
                table: "orders",
                columns: new[] { "company_id", "idempotency_key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_payments_company_id_order_id",
                schema: "pos",
                table: "order_payments",
                columns: new[] { "company_id", "order_id" });

            migrationBuilder.CreateIndex(
                name: "IX_loyalty_point_transactions_company_id_order_id",
                schema: "pos",
                table: "loyalty_point_transactions",
                columns: new[] { "company_id", "order_id" });

            migrationBuilder.CreateIndex(
                name: "IX_loyalty_accounts_company_id_customer_id",
                schema: "pos",
                table: "loyalty_accounts",
                columns: new[] { "company_id", "customer_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_wallet_transactions_company_id_order_id",
                schema: "pos",
                table: "wallet_transactions");

            migrationBuilder.DropIndex(
                name: "IX_wallet_accounts_company_id_customer_id_currency",
                schema: "pos",
                table: "wallet_accounts");

            migrationBuilder.DropIndex(
                name: "IX_store_products_store_id_product_id",
                schema: "pos",
                table: "store_products");

            migrationBuilder.DropIndex(
                name: "IX_stock_movements_company_id_operation_id_movement_type",
                schema: "pos",
                table: "stock_movements");

            migrationBuilder.DropIndex(
                name: "IX_orders_company_id_idempotency_key",
                schema: "pos",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_order_payments_company_id_order_id",
                schema: "pos",
                table: "order_payments");

            migrationBuilder.DropIndex(
                name: "IX_loyalty_point_transactions_company_id_order_id",
                schema: "pos",
                table: "loyalty_point_transactions");

            migrationBuilder.DropIndex(
                name: "IX_loyalty_accounts_company_id_customer_id",
                schema: "pos",
                table: "loyalty_accounts");

            migrationBuilder.DropColumn(
                name: "idempotency_key",
                schema: "pos",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "payment_summary",
                schema: "pos",
                table: "orders");

            migrationBuilder.CreateIndex(
                name: "IX_store_products_store_id",
                schema: "pos",
                table: "store_products",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_company_id",
                schema: "pos",
                table: "orders",
                column: "company_id");
        }
    }
}
