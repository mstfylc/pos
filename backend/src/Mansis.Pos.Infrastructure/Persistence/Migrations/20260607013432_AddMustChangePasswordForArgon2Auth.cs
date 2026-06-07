using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mansis.Pos.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMustChangePasswordForArgon2Auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "must_change_password",
                schema: "pos",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "must_change_password",
                schema: "pos",
                table: "customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "must_change_password",
                schema: "pos",
                table: "users");

            migrationBuilder.DropColumn(
                name: "must_change_password",
                schema: "pos",
                table: "customers");
        }
    }
}
