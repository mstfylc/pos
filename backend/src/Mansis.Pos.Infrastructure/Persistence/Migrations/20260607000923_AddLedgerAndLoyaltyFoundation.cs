using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mansis.Pos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLedgerAndLoyaltyFoundation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pos");

            migrationBuilder.CreateTable(
                name: "cities",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    mail = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "earn_rules",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    amount_per_point = table.Column<decimal>(type: "numeric", nullable: false),
                    starts_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ends_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_earn_rules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loyalty_tiers",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    minimum_points = table.Column<int>(type: "integer", nullable: false),
                    earn_multiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loyalty_tiers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: true),
                    permission_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rewards",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    required_points = table.Column<int>(type: "integer", nullable: false),
                    discount_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rewards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "towns",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    city_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_towns", x => x.id);
                    table.ForeignKey(
                        name: "FK_towns_cities_city_id",
                        column: x => x.city_id,
                        principalSchema: "pos",
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.id);
                    table.ForeignKey(
                        name: "FK_branches_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "campaigns",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    starts_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ends_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaigns", x => x.id);
                    table.ForeignKey(
                        name: "FK_campaigns_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_cards_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_colors",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_colors", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_colors_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_shapes",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_shapes", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_shapes_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "company_activity_logs",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    log_activity_type = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_activity_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_company_activity_logs_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "config_params",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config_params", x => x.id);
                    table.ForeignKey(
                        name: "FK_config_params_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    max_discount_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    expire_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    discount_type = table.Column<string>(type: "text", nullable: false),
                    discount_category = table.Column<string>(type: "text", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_discounts_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_roles_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    authorized_person = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    mail = table.Column<string>(type: "text", nullable: true),
                    tax_office = table.Column<string>(type: "text", nullable: true),
                    tax_no = table.Column<string>(type: "text", nullable: true),
                    tax_free = table.Column<bool>(type: "boolean", nullable: true),
                    money_unit_type = table.Column<string>(type: "text", nullable: true),
                    maturity = table.Column<int>(type: "integer", nullable: true),
                    opening_balance = table.Column<decimal>(type: "numeric", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                    table.ForeignKey(
                        name: "FK_suppliers_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_colors",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_colors", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_colors_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_shapes",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_shapes", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_shapes_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_type = table.Column<string>(type: "text", nullable: false),
                    address_header = table.Column<string>(type: "text", nullable: true),
                    city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    town_id = table.Column<Guid>(type: "uuid", nullable: false),
                    district = table.Column<string>(type: "text", nullable: true),
                    mobile_phone = table.Column<string>(type: "text", nullable: true),
                    business_phone = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_cities_city_id",
                        column: x => x.city_id,
                        principalSchema: "pos",
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_addresses_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_addresses_towns_town_id",
                        column: x => x.town_id,
                        principalSchema: "pos",
                        principalTable: "towns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "branch_activity_logs",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    log_activity_type = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch_activity_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_branch_activity_logs_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "pos",
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.id);
                    table.ForeignKey(
                        name: "FK_stores_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "pos",
                        principalTable: "branches",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_stores_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    be_printed = table.Column<bool>(type: "boolean", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_color_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_shape_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_categories_category_colors_category_color_id",
                        column: x => x.category_color_id,
                        principalSchema: "pos",
                        principalTable: "category_colors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categories_category_shapes_category_shape_id",
                        column: x => x.category_shape_id,
                        principalSchema: "pos",
                        principalTable: "category_shapes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categories_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount_branches",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    discount_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_branches", x => x.id);
                    table.ForeignKey(
                        name: "FK_discount_branches_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "pos",
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_branches_discounts_discount_id",
                        column: x => x.discount_id,
                        principalSchema: "pos",
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    mail = table.Column<string>(type: "text", nullable: true),
                    password_hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    password_salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    photo = table.Column<string>(type: "text", nullable: true),
                    registered = table.Column<bool>(type: "boolean", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_customers_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customers_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "pos",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_role_permissions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "pos",
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "pos",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    mail = table.Column<string>(type: "text", nullable: true),
                    password_hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    password_salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    pin = table.Column<string>(type: "text", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_cards_card_id",
                        column: x => x.card_id,
                        principalSchema: "pos",
                        principalTable: "cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "pos",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_color_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_shape_id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                    table.ForeignKey(
                        name: "FK_tags_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tags_tag_colors_tag_color_id",
                        column: x => x.tag_color_id,
                        principalSchema: "pos",
                        principalTable: "tag_colors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tags_tag_shapes_tag_shape_id",
                        column: x => x.tag_shape_id,
                        principalSchema: "pos",
                        principalTable: "tag_shapes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_devices",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_devices", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_devices_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "pos",
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_devices_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_devices_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "pos",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_activity_logs",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    log_activity_type = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_activity_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_store_activity_logs_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "pos",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    purchase_price = table.Column<decimal>(type: "numeric", nullable: true),
                    sale_price = table.Column<decimal>(type: "numeric", nullable: true),
                    stock_code = table.Column<string>(type: "text", nullable: true),
                    store_product = table.Column<bool>(type: "boolean", nullable: false),
                    pos_product = table.Column<bool>(type: "boolean", nullable: false),
                    stocktaking = table.Column<bool>(type: "boolean", nullable: false),
                    entry_product = table.Column<bool>(type: "boolean", nullable: false),
                    favorite_product = table.Column<bool>(type: "boolean", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    product_unit_type = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: true),
                    tax_type = table.Column<string>(type: "text", nullable: false),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    main = table.Column<bool>(type: "boolean", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "pos",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_products_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "customer_addresses",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_addresses_addresses_address_id",
                        column: x => x.address_id,
                        principalSchema: "pos",
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_addresses_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_balance_movements",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    balance_movement_type = table.Column<string>(type: "text", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_balance_movements", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_balance_movements_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_balance_movements_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "device_tokens",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    token_hash = table.Column<string>(type: "text", nullable: false),
                    platform = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    revoked_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_device_tokens_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loyalty_accounts",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    loyalty_tier_id = table.Column<Guid>(type: "uuid", nullable: true),
                    point_balance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loyalty_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_loyalty_accounts_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_loyalty_accounts_loyalty_tiers_loyalty_tier_id",
                        column: x => x.loyalty_tier_id,
                        principalSchema: "pos",
                        principalTable: "loyalty_tiers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "reward_redemptions",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reward_id = table.Column<Guid>(type: "uuid", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    reversal_of_id = table.Column<Guid>(type: "uuid", nullable: true),
                    requested_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reward_redemptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_reward_redemptions_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reward_redemptions_reward_redemptions_reversal_of_id",
                        column: x => x.reversal_of_id,
                        principalSchema: "pos",
                        principalTable: "reward_redemptions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_reward_redemptions_rewards_reward_id",
                        column: x => x.reward_id,
                        principalSchema: "pos",
                        principalTable: "rewards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wallet_accounts",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency = table.Column<string>(type: "text", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallet_accounts_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assignments",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assignment_table_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_assignments_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "branch_managers",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    manager_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch_managers", x => x.id);
                    table.ForeignKey(
                        name: "FK_branch_managers_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "pos",
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_branch_managers_users_manager_id",
                        column: x => x.manager_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "branch_users",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_branch_users_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "pos",
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_branch_users_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "company_owners",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_owners", x => x.id);
                    table.ForeignKey(
                        name: "FK_company_owners_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_company_owners_users_owner_id",
                        column: x => x.owner_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount_users",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    discount_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_discount_users_discounts_discount_id",
                        column: x => x.discount_id,
                        principalSchema: "pos",
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_users_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "password_reset_tokens",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    token_hash = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    expires_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_reset_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_password_reset_tokens_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_password_reset_tokens_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchase_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    invoice = table.Column<string>(type: "text", nullable: true),
                    total = table.Column<decimal>(type: "numeric", nullable: false),
                    payment_completed = table.Column<bool>(type: "boolean", nullable: false),
                    received = table.Column<bool>(type: "boolean", nullable: false),
                    payer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    receiver_id = table.Column<Guid>(type: "uuid", nullable: true),
                    supplier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchases_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchases_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "pos",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchases_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalSchema: "pos",
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchases_users_payer_id",
                        column: x => x.payer_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_purchases_users_receiver_id",
                        column: x => x.receiver_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    token_hash = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    expires_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    revoked_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_refresh_tokens_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_product_transfers",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    transfer_state = table.Column<string>(type: "text", nullable: false),
                    source_store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    target_store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requested_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requested_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    confirmed_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    confirmed_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    received_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    received_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    transfer_done = table.Column<bool>(type: "boolean", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_product_transfers", x => x.id);
                    table.ForeignKey(
                        name: "FK_store_product_transfers_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_store_product_transfers_stores_source_store_id",
                        column: x => x.source_store_id,
                        principalSchema: "pos",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_store_product_transfers_stores_target_store_id",
                        column: x => x.target_store_id,
                        principalSchema: "pos",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_store_product_transfers_users_confirmed_by_id",
                        column: x => x.confirmed_by_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_store_product_transfers_users_received_by_id",
                        column: x => x.received_by_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_store_product_transfers_users_requested_by_id",
                        column: x => x.requested_by_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_activity_logs",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    log_activity_type = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_activity_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_activity_logs_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_branches",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_branches", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_branches_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "pos",
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tag_branches_tags_tag_id",
                        column: x => x.tag_id,
                        principalSchema: "pos",
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_discounts",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false),
                    discount_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_discounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_discounts_discounts_discount_id",
                        column: x => x.discount_id,
                        principalSchema: "pos",
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tag_discounts_tags_tag_id",
                        column: x => x.tag_id,
                        principalSchema: "pos",
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount_poses",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    discount_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pos_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_poses", x => x.id);
                    table.ForeignKey(
                        name: "FK_discount_poses_discounts_discount_id",
                        column: x => x.discount_id,
                        principalSchema: "pos",
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_poses_pos_devices_pos_id",
                        column: x => x.pos_id,
                        principalSchema: "pos",
                        principalTable: "pos_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "load_balance_requests",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pos_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requested_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    confirm_code = table.Column<int>(type: "integer", nullable: false),
                    requested_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_load_balance_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_load_balance_requests_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_load_balance_requests_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_load_balance_requests_pos_devices_pos_id",
                        column: x => x.pos_id,
                        principalSchema: "pos",
                        principalTable: "pos_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_load_balance_requests_users_requested_by_id",
                        column: x => x.requested_by_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sub_total = table.Column<decimal>(type: "numeric", nullable: false),
                    tax_total = table.Column<decimal>(type: "numeric", nullable: false),
                    total_discount = table.Column<decimal>(type: "numeric", nullable: true),
                    total = table.Column<decimal>(type: "numeric", nullable: false),
                    shipping_type = table.Column<string>(type: "text", nullable: false),
                    order_state = table.Column<string>(type: "text", nullable: false),
                    order_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    is_closed = table.Column<bool>(type: "boolean", nullable: false),
                    offline_order = table.Column<bool>(type: "boolean", nullable: false),
                    update_reason = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    address_id = table.Column<Guid>(type: "uuid", nullable: true),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    pos_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_addresses_address_id",
                        column: x => x.address_id,
                        principalSchema: "pos",
                        principalTable: "addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orders_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orders_pos_devices_pos_id",
                        column: x => x.pos_id,
                        principalSchema: "pos",
                        principalTable: "pos_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_activity_logs",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    pos_id = table.Column<Guid>(type: "uuid", nullable: false),
                    log_activity_type = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_activity_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_activity_logs_pos_devices_pos_id",
                        column: x => x.pos_id,
                        principalSchema: "pos",
                        principalTable: "pos_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_users",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    pos_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_users_pos_devices_pos_id",
                        column: x => x.pos_id,
                        principalSchema: "pos",
                        principalTable: "pos_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_users_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_poses",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pos_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_poses", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_poses_pos_devices_pos_id",
                        column: x => x.pos_id,
                        principalSchema: "pos",
                        principalTable: "pos_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tag_poses_tags_tag_id",
                        column: x => x.tag_id,
                        principalSchema: "pos",
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_favorite_products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_favorite_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_favorite_products_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_favorite_products_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "pos",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_favorite_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pos_products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchase_price = table.Column<decimal>(type: "numeric", nullable: true),
                    sale_price = table.Column<decimal>(type: "numeric", nullable: true),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pos_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pos_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_pos_products_pos_devices_pos_id",
                        column: x => x.pos_id,
                        principalSchema: "pos",
                        principalTable: "pos_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pos_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_sub_products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    visible = table.Column<bool>(type: "boolean", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sub_product_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_sub_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_sub_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_sub_products_products_sub_product_id",
                        column: x => x.sub_product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stock_movements",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    operation_id = table.Column<Guid>(type: "uuid", nullable: true),
                    movement_type = table.Column<string>(type: "text", nullable: false),
                    direction = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    reversal_of_id = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    occurred_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_movements", x => x.id);
                    table.ForeignKey(
                        name: "FK_stock_movements_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stock_movements_stock_movements_reversal_of_id",
                        column: x => x.reversal_of_id,
                        principalSchema: "pos",
                        principalTable: "stock_movements",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_stock_movements_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "pos",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_product_movements",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    movement_type = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    operation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    operation_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_product_movements", x => x.id);
                    table.ForeignKey(
                        name: "FK_store_product_movements_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_store_product_movements_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "pos",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    quantity_after_stock_count = table.Column<int>(type: "integer", nullable: true),
                    stock_diff = table.Column<int>(type: "integer", nullable: true),
                    threshold = table.Column<int>(type: "integer", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_store_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_store_products_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "pos",
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tag_products_tags_tag_id",
                        column: x => x.tag_id,
                        principalSchema: "pos",
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assignment_records",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_name = table.Column<string>(type: "text", nullable: false),
                    assignment_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment_records", x => x.id);
                    table.ForeignKey(
                        name: "FK_assignment_records_assignments_assignment_id",
                        column: x => x.assignment_id,
                        principalSchema: "pos",
                        principalTable: "assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchase_products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    total = table.Column<decimal>(type: "numeric", nullable: false),
                    discount = table.Column<int>(type: "integer", nullable: true),
                    tax = table.Column<int>(type: "integer", nullable: true),
                    purchase_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchase_products_purchases_purchase_id",
                        column: x => x.purchase_id,
                        principalSchema: "pos",
                        principalTable: "purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_product_transfer_details",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_product_transfer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    received_quantity = table.Column<int>(type: "integer", nullable: true),
                    unit = table.Column<string>(type: "text", nullable: true),
                    unit_price = table.Column<decimal>(type: "numeric", nullable: true),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_product_transfer_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_store_product_transfer_details_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_store_product_transfer_details_store_product_transfers_stor~",
                        column: x => x.store_product_transfer_id,
                        principalSchema: "pos",
                        principalTable: "store_product_transfers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discount_usage_logs",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    order_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    discount_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount_usage_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_discount_usage_logs_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "pos",
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_usage_logs_discounts_discount_id",
                        column: x => x.discount_id,
                        principalSchema: "pos",
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_usage_logs_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "pos",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discount_usage_logs_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loyalty_point_transactions",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    loyalty_account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    transaction_type = table.Column<string>(type: "text", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    reversal_of_id = table.Column<Guid>(type: "uuid", nullable: true),
                    occurred_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loyalty_point_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_loyalty_point_transactions_loyalty_accounts_loyalty_account~",
                        column: x => x.loyalty_account_id,
                        principalSchema: "pos",
                        principalTable: "loyalty_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_loyalty_point_transactions_loyalty_point_transactions_rever~",
                        column: x => x.reversal_of_id,
                        principalSchema: "pos",
                        principalTable: "loyalty_point_transactions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_loyalty_point_transactions_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "pos",
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_discounts",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    discount_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_discounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_discounts_discounts_discount_id",
                        column: x => x.discount_id,
                        principalSchema: "pos",
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_discounts_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "pos",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_discounts_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "pos",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_payments",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_type = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    currency = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    external_reference = table.Column<string>(type: "text", nullable: true),
                    reversal_of_id = table.Column<Guid>(type: "uuid", nullable: true),
                    paid_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_payments_order_payments_reversal_of_id",
                        column: x => x.reversal_of_id,
                        principalSchema: "pos",
                        principalTable: "order_payments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_order_payments_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "pos",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<decimal>(type: "numeric", nullable: true),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_products_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "pos",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_orders",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_orders_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "pos",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tag_orders_tags_tag_id",
                        column: x => x.tag_id,
                        principalSchema: "pos",
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wallet_transactions",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    wallet_account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    direction = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    reversal_of_id = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    occurred_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallet_transactions_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "pos",
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_wallet_transactions_wallet_accounts_wallet_account_id",
                        column: x => x.wallet_account_id,
                        principalSchema: "pos",
                        principalTable: "wallet_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wallet_transactions_wallet_transactions_reversal_of_id",
                        column: x => x.reversal_of_id,
                        principalSchema: "pos",
                        principalTable: "wallet_transactions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_sub_products",
                schema: "pos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_sub_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_sub_products_order_products_order_product_id",
                        column: x => x.order_product_id,
                        principalSchema: "pos",
                        principalTable: "order_products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_sub_products_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "pos",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_sub_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "pos",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_city_id",
                schema: "pos",
                table: "addresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_company_id",
                schema: "pos",
                table: "addresses",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_town_id",
                schema: "pos",
                table: "addresses",
                column: "town_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_records_assignment_id",
                schema: "pos",
                table: "assignment_records",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignments_user_id",
                schema: "pos",
                table: "assignments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_activity_logs_branch_id",
                schema: "pos",
                table: "branch_activity_logs",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_managers_branch_id",
                schema: "pos",
                table: "branch_managers",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_managers_manager_id",
                schema: "pos",
                table: "branch_managers",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_users_branch_id",
                schema: "pos",
                table: "branch_users",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_branch_users_user_id",
                schema: "pos",
                table: "branch_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_branches_company_id",
                schema: "pos",
                table: "branches",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_campaigns_company_id",
                schema: "pos",
                table: "campaigns",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_cards_company_id",
                schema: "pos",
                table: "cards",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_category_color_id",
                schema: "pos",
                table: "categories",
                column: "category_color_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_category_shape_id",
                schema: "pos",
                table: "categories",
                column: "category_shape_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_company_id",
                schema: "pos",
                table: "categories",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_colors_company_id",
                schema: "pos",
                table: "category_colors",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_shapes_company_id",
                schema: "pos",
                table: "category_shapes",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_activity_logs_company_id",
                schema: "pos",
                table: "company_activity_logs",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_owners_company_id",
                schema: "pos",
                table: "company_owners",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_owners_owner_id",
                schema: "pos",
                table: "company_owners",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_config_params_company_id",
                schema: "pos",
                table: "config_params",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_addresses_address_id",
                schema: "pos",
                table: "customer_addresses",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_addresses_customer_id",
                schema: "pos",
                table: "customer_addresses",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_balance_movements_company_id",
                schema: "pos",
                table: "customer_balance_movements",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_balance_movements_customer_id",
                schema: "pos",
                table: "customer_balance_movements",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_favorite_products_company_id",
                schema: "pos",
                table: "customer_favorite_products",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_favorite_products_customer_id",
                schema: "pos",
                table: "customer_favorite_products",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_favorite_products_product_id",
                schema: "pos",
                table: "customer_favorite_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_company_id",
                schema: "pos",
                table: "customers",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_role_id",
                schema: "pos",
                table: "customers",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_device_tokens_customer_id",
                schema: "pos",
                table: "device_tokens",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_branches_branch_id",
                schema: "pos",
                table: "discount_branches",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_branches_discount_id",
                schema: "pos",
                table: "discount_branches",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_poses_discount_id",
                schema: "pos",
                table: "discount_poses",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_poses_pos_id",
                schema: "pos",
                table: "discount_poses",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_usage_logs_company_id",
                schema: "pos",
                table: "discount_usage_logs",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_usage_logs_discount_id",
                schema: "pos",
                table: "discount_usage_logs",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_usage_logs_order_id",
                schema: "pos",
                table: "discount_usage_logs",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_usage_logs_user_id",
                schema: "pos",
                table: "discount_usage_logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_users_discount_id",
                schema: "pos",
                table: "discount_users",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_discount_users_user_id",
                schema: "pos",
                table: "discount_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_discounts_company_id",
                schema: "pos",
                table: "discounts",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_balance_requests_company_id",
                schema: "pos",
                table: "load_balance_requests",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_balance_requests_customer_id",
                schema: "pos",
                table: "load_balance_requests",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_balance_requests_pos_id",
                schema: "pos",
                table: "load_balance_requests",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_balance_requests_requested_by_id",
                schema: "pos",
                table: "load_balance_requests",
                column: "requested_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_loyalty_accounts_customer_id",
                schema: "pos",
                table: "loyalty_accounts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_loyalty_accounts_loyalty_tier_id",
                schema: "pos",
                table: "loyalty_accounts",
                column: "loyalty_tier_id");

            migrationBuilder.CreateIndex(
                name: "IX_loyalty_point_transactions_loyalty_account_id",
                schema: "pos",
                table: "loyalty_point_transactions",
                column: "loyalty_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_loyalty_point_transactions_order_id",
                schema: "pos",
                table: "loyalty_point_transactions",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_loyalty_point_transactions_reversal_of_id",
                schema: "pos",
                table: "loyalty_point_transactions",
                column: "reversal_of_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_discounts_discount_id",
                schema: "pos",
                table: "order_discounts",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_discounts_order_id",
                schema: "pos",
                table: "order_discounts",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_discounts_user_id",
                schema: "pos",
                table: "order_discounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_payments_order_id",
                schema: "pos",
                table: "order_payments",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_payments_reversal_of_id",
                schema: "pos",
                table: "order_payments",
                column: "reversal_of_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_products_order_id",
                schema: "pos",
                table: "order_products",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_products_product_id",
                schema: "pos",
                table: "order_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_sub_products_order_id",
                schema: "pos",
                table: "order_sub_products",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_sub_products_order_product_id",
                schema: "pos",
                table: "order_sub_products",
                column: "order_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_sub_products_product_id",
                schema: "pos",
                table: "order_sub_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_address_id",
                schema: "pos",
                table: "orders",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_company_id",
                schema: "pos",
                table: "orders",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                schema: "pos",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_pos_id",
                schema: "pos",
                table: "orders",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                schema: "pos",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_password_reset_tokens_customer_id",
                schema: "pos",
                table: "password_reset_tokens",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_password_reset_tokens_user_id",
                schema: "pos",
                table: "password_reset_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_activity_logs_pos_id",
                schema: "pos",
                table: "pos_activity_logs",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_devices_branch_id",
                schema: "pos",
                table: "pos_devices",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_devices_company_id",
                schema: "pos",
                table: "pos_devices",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_devices_store_id",
                schema: "pos",
                table: "pos_devices",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_products_pos_id",
                schema: "pos",
                table: "pos_products",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_products_product_id",
                schema: "pos",
                table: "pos_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_users_pos_id",
                schema: "pos",
                table: "pos_users",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_pos_users_user_id",
                schema: "pos",
                table: "pos_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_sub_products_product_id",
                schema: "pos",
                table: "product_sub_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_sub_products_sub_product_id",
                schema: "pos",
                table: "product_sub_products",
                column: "sub_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                schema: "pos",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_company_id",
                schema: "pos",
                table: "products",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_parent_id",
                schema: "pos",
                table: "products",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_products_purchase_id",
                schema: "pos",
                table: "purchase_products",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_company_id",
                schema: "pos",
                table: "purchases",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_payer_id",
                schema: "pos",
                table: "purchases",
                column: "payer_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_receiver_id",
                schema: "pos",
                table: "purchases",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_store_id",
                schema: "pos",
                table: "purchases",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_supplier_id",
                schema: "pos",
                table: "purchases",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_user_id",
                schema: "pos",
                table: "refresh_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_reward_redemptions_customer_id",
                schema: "pos",
                table: "reward_redemptions",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_reward_redemptions_reversal_of_id",
                schema: "pos",
                table: "reward_redemptions",
                column: "reversal_of_id");

            migrationBuilder.CreateIndex(
                name: "IX_reward_redemptions_reward_id",
                schema: "pos",
                table: "reward_redemptions",
                column: "reward_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_permission_id",
                schema: "pos",
                table: "role_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_role_id",
                schema: "pos",
                table: "role_permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_company_id",
                schema: "pos",
                table: "roles",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_movements_product_id",
                schema: "pos",
                table: "stock_movements",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_movements_reversal_of_id",
                schema: "pos",
                table: "stock_movements",
                column: "reversal_of_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_movements_store_id",
                schema: "pos",
                table: "stock_movements",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_activity_logs_store_id",
                schema: "pos",
                table: "store_activity_logs",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_movements_product_id",
                schema: "pos",
                table: "store_product_movements",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_movements_store_id",
                schema: "pos",
                table: "store_product_movements",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfer_details_product_id",
                schema: "pos",
                table: "store_product_transfer_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfer_details_store_product_transfer_id",
                schema: "pos",
                table: "store_product_transfer_details",
                column: "store_product_transfer_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfers_company_id",
                schema: "pos",
                table: "store_product_transfers",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfers_confirmed_by_id",
                schema: "pos",
                table: "store_product_transfers",
                column: "confirmed_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfers_received_by_id",
                schema: "pos",
                table: "store_product_transfers",
                column: "received_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfers_requested_by_id",
                schema: "pos",
                table: "store_product_transfers",
                column: "requested_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfers_source_store_id",
                schema: "pos",
                table: "store_product_transfers",
                column: "source_store_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_product_transfers_target_store_id",
                schema: "pos",
                table: "store_product_transfers",
                column: "target_store_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_products_product_id",
                schema: "pos",
                table: "store_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_products_store_id",
                schema: "pos",
                table: "store_products",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_stores_branch_id",
                schema: "pos",
                table: "stores",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_stores_company_id",
                schema: "pos",
                table: "stores",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_company_id",
                schema: "pos",
                table: "suppliers",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_branches_branch_id",
                schema: "pos",
                table: "tag_branches",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_branches_tag_id",
                schema: "pos",
                table: "tag_branches",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_colors_company_id",
                schema: "pos",
                table: "tag_colors",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_discounts_discount_id",
                schema: "pos",
                table: "tag_discounts",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_discounts_tag_id",
                schema: "pos",
                table: "tag_discounts",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_orders_order_id",
                schema: "pos",
                table: "tag_orders",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_orders_tag_id",
                schema: "pos",
                table: "tag_orders",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_poses_pos_id",
                schema: "pos",
                table: "tag_poses",
                column: "pos_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_poses_tag_id",
                schema: "pos",
                table: "tag_poses",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_products_product_id",
                schema: "pos",
                table: "tag_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_products_tag_id",
                schema: "pos",
                table: "tag_products",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_shapes_company_id",
                schema: "pos",
                table: "tag_shapes",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tags_company_id",
                schema: "pos",
                table: "tags",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tags_tag_color_id",
                schema: "pos",
                table: "tags",
                column: "tag_color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tags_tag_shape_id",
                schema: "pos",
                table: "tags",
                column: "tag_shape_id");

            migrationBuilder.CreateIndex(
                name: "IX_towns_city_id",
                schema: "pos",
                table: "towns",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_activity_logs_user_id",
                schema: "pos",
                table: "user_activity_logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_card_id",
                schema: "pos",
                table: "users",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_company_id",
                schema: "pos",
                table: "users",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                schema: "pos",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_accounts_customer_id",
                schema: "pos",
                table: "wallet_accounts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transactions_order_id",
                schema: "pos",
                table: "wallet_transactions",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transactions_reversal_of_id",
                schema: "pos",
                table: "wallet_transactions",
                column: "reversal_of_id");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transactions_wallet_account_id",
                schema: "pos",
                table: "wallet_transactions",
                column: "wallet_account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignment_records",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "branch_activity_logs",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "branch_managers",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "branch_users",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "campaigns",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "company_activity_logs",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "company_owners",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "config_params",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "customer_addresses",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "customer_balance_movements",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "customer_favorite_products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "device_tokens",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "discount_branches",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "discount_poses",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "discount_usage_logs",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "discount_users",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "earn_rules",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "load_balance_requests",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "loyalty_point_transactions",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "order_discounts",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "order_payments",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "order_sub_products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "password_reset_tokens",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "pos_activity_logs",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "pos_products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "pos_users",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "product_sub_products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "purchase_products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "refresh_tokens",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "reward_redemptions",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "role_permissions",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "stock_movements",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "store_activity_logs",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "store_product_movements",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "store_product_transfer_details",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "store_products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "tag_branches",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "tag_discounts",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "tag_orders",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "tag_poses",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "tag_products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "user_activity_logs",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "wallet_transactions",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "assignments",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "loyalty_accounts",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "order_products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "purchases",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "rewards",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "store_product_transfers",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "discounts",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "tags",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "wallet_accounts",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "loyalty_tiers",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "products",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "suppliers",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "tag_colors",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "tag_shapes",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "addresses",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "pos_devices",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "users",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "towns",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "cards",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "category_colors",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "category_shapes",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "cities",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "branches",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "companies",
                schema: "pos");
        }
    }
}
