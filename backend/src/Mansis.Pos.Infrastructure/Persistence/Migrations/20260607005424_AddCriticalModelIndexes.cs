using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mansis.Pos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCriticalModelIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tag_products_tag_id",
                schema: "pos",
                table: "tag_products");

            migrationBuilder.DropIndex(
                name: "IX_tag_orders_tag_id",
                schema: "pos",
                table: "tag_orders");

            migrationBuilder.DropIndex(
                name: "IX_role_permissions_role_id",
                schema: "pos",
                table: "role_permissions");

            migrationBuilder.DropIndex(
                name: "IX_products_company_id",
                schema: "pos",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_product_sub_products_product_id",
                schema: "pos",
                table: "product_sub_products");

            migrationBuilder.DropIndex(
                name: "IX_pos_users_pos_id",
                schema: "pos",
                table: "pos_users");

            migrationBuilder.DropIndex(
                name: "IX_pos_products_pos_id",
                schema: "pos",
                table: "pos_products");

            migrationBuilder.DropIndex(
                name: "IX_discount_usage_logs_company_id",
                schema: "pos",
                table: "discount_usage_logs");

            migrationBuilder.DropIndex(
                name: "IX_customers_company_id",
                schema: "pos",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_branch_users_branch_id",
                schema: "pos",
                table: "branch_users");

            migrationBuilder.CreateIndex(
                name: "IX_tag_products_tag_id_product_id",
                schema: "pos",
                table: "tag_products",
                columns: new[] { "tag_id", "product_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tag_orders_tag_id_order_id",
                schema: "pos",
                table: "tag_orders",
                columns: new[] { "tag_id", "order_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_role_id_permission_id",
                schema: "pos",
                table: "role_permissions",
                columns: new[] { "role_id", "permission_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_company_id_barcode",
                schema: "pos",
                table: "products",
                columns: new[] { "company_id", "barcode" });

            migrationBuilder.CreateIndex(
                name: "IX_products_company_id_category_id_active",
                schema: "pos",
                table: "products",
                columns: new[] { "company_id", "category_id", "active" });

            migrationBuilder.CreateIndex(
                name: "IX_products_company_id_stock_code",
                schema: "pos",
                table: "products",
                columns: new[] { "company_id", "stock_code" });

            migrationBuilder.CreateIndex(
                name: "IX_product_sub_products_product_id_sub_product_id",
                schema: "pos",
                table: "product_sub_products",
                columns: new[] { "product_id", "sub_product_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pos_users_pos_id_user_id",
                schema: "pos",
                table: "pos_users",
                columns: new[] { "pos_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pos_products_pos_id_product_id",
                schema: "pos",
                table: "pos_products",
                columns: new[] { "pos_id", "product_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_company_id_customer_id_order_time",
                schema: "pos",
                table: "orders",
                columns: new[] { "company_id", "customer_id", "order_time" });

            migrationBuilder.CreateIndex(
                name: "IX_orders_company_id_pos_id_order_time",
                schema: "pos",
                table: "orders",
                columns: new[] { "company_id", "pos_id", "order_time" });

            migrationBuilder.CreateIndex(
                name: "IX_discount_usage_logs_company_id_discount_id_order_time",
                schema: "pos",
                table: "discount_usage_logs",
                columns: new[] { "company_id", "discount_id", "order_time" });

            migrationBuilder.CreateIndex(
                name: "IX_discount_usage_logs_company_id_order_id",
                schema: "pos",
                table: "discount_usage_logs",
                columns: new[] { "company_id", "order_id" });

            migrationBuilder.CreateIndex(
                name: "IX_customers_company_id_mail",
                schema: "pos",
                table: "customers",
                columns: new[] { "company_id", "mail" });

            migrationBuilder.CreateIndex(
                name: "IX_customers_company_id_phone",
                schema: "pos",
                table: "customers",
                columns: new[] { "company_id", "phone" });

            migrationBuilder.CreateIndex(
                name: "IX_customers_company_id_username",
                schema: "pos",
                table: "customers",
                columns: new[] { "company_id", "username" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_branch_users_branch_id_user_id",
                schema: "pos",
                table: "branch_users",
                columns: new[] { "branch_id", "user_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tag_products_tag_id_product_id",
                schema: "pos",
                table: "tag_products");

            migrationBuilder.DropIndex(
                name: "IX_tag_orders_tag_id_order_id",
                schema: "pos",
                table: "tag_orders");

            migrationBuilder.DropIndex(
                name: "IX_role_permissions_role_id_permission_id",
                schema: "pos",
                table: "role_permissions");

            migrationBuilder.DropIndex(
                name: "IX_products_company_id_barcode",
                schema: "pos",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_company_id_category_id_active",
                schema: "pos",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_company_id_stock_code",
                schema: "pos",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_product_sub_products_product_id_sub_product_id",
                schema: "pos",
                table: "product_sub_products");

            migrationBuilder.DropIndex(
                name: "IX_pos_users_pos_id_user_id",
                schema: "pos",
                table: "pos_users");

            migrationBuilder.DropIndex(
                name: "IX_pos_products_pos_id_product_id",
                schema: "pos",
                table: "pos_products");

            migrationBuilder.DropIndex(
                name: "IX_orders_company_id_customer_id_order_time",
                schema: "pos",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_company_id_pos_id_order_time",
                schema: "pos",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_discount_usage_logs_company_id_discount_id_order_time",
                schema: "pos",
                table: "discount_usage_logs");

            migrationBuilder.DropIndex(
                name: "IX_discount_usage_logs_company_id_order_id",
                schema: "pos",
                table: "discount_usage_logs");

            migrationBuilder.DropIndex(
                name: "IX_customers_company_id_mail",
                schema: "pos",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_company_id_phone",
                schema: "pos",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_company_id_username",
                schema: "pos",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_branch_users_branch_id_user_id",
                schema: "pos",
                table: "branch_users");

            migrationBuilder.CreateIndex(
                name: "IX_tag_products_tag_id",
                schema: "pos",
                table: "tag_products",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_orders_tag_id",
                schema: "pos",
                table: "tag_orders",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_role_id",
                schema: "pos",
                table: "role_permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_company_id",
                schema: "pos",
                table: "products",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_sub_products_product_id",
                schema: "pos",
                table: "product_sub_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_users_pos_id",
                schema: "pos",
                table: "pos_users",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_products_pos_id",
                schema: "pos",
                table: "pos_products",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_usage_logs_company_id",
                schema: "pos",
                table: "discount_usage_logs",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_company_id",
                schema: "pos",
                table: "customers",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_users_branch_id",
                schema: "pos",
                table: "branch_users",
                column: "branch_id");
        }
    }
}
