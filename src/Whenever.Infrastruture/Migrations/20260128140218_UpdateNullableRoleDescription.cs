using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Whenever.Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNullableRoleDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "sizes",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "shipping_addresses",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "products",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "product_sizes",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "product_inventories",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "product_forms",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "product_fabrics",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "product_colors",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "personalization_users",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "orders",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "order_items",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "images",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "colors",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "categories",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "cart_items",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "banners",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "application_logs",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "accessory_inventories",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "accessory_categories",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "application",
                table: "accessories",
                newName: "updated_date");

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                schema: "application",
                table: "role",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "application",
                table: "role",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "sizes",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "shipping_addresses",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "products",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "product_sizes",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "product_inventories",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "product_forms",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "product_fabrics",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "product_colors",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "personalization_users",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "orders",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "order_items",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "images",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "colors",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "categories",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "cart_items",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "banners",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "application_logs",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "accessory_inventories",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "accessory_categories",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                schema: "application",
                table: "accessories",
                newName: "update_date");

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                schema: "application",
                table: "role",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "application",
                table: "role",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
