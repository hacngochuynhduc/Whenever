using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Whenever.Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "application");

            migrationBuilder.CreateTable(
                name: "application_logs",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    log_level = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    exception = table.Column<string>(type: "text", nullable: true),
                    stack_trace = table.Column<string>(type: "text", nullable: true),
                    request_path = table.Column<string>(type: "text", nullable: true),
                    request_method = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    ip_address = table.Column<string>(type: "text", nullable: true),
                    user_agent = table.Column<string>(type: "text", nullable: true),
                    machine_name = table.Column<string>(type: "text", nullable: true),
                    operating_system = table.Column<string>(type: "text", nullable: true),
                    duration_ms = table.Column<long>(type: "bigint", nullable: true),
                    status_code = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "banners",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    thumbnail_url = table.Column<string>(type: "text", nullable: true),
                    display_priorirty = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_banners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "colors",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    color_name = table.Column<string>(type: "text", nullable: false),
                    hex_value = table.Column<string>(type: "text", nullable: false),
                    default_color = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_colors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personalization_users",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    avatar_url = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    stress_address = table.Column<string>(type: "text", nullable: false),
                    province = table.Column<string>(type: "text", nullable: false),
                    ward = table.Column<string>(type: "text", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_login = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    first_login = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    google_id = table.Column<string>(type: "text", nullable: true),
                    facebook_id = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personalization_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    slug = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sizes",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    size_name = table.Column<string>(type: "text", nullable: false),
                    size_description = table.Column<string>(type: "text", nullable: false),
                    size_chart_url = table.Column<string>(type: "text", nullable: false),
                    default_size = table.Column<bool>(type: "boolean", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sizes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_type = table.Column<int>(type: "integer", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    avatar_url = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    price_excluding_tax = table.Column<decimal>(type: "numeric", nullable: false),
                    vat_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    vat_rate = table.Column<decimal>(type: "numeric", nullable: false),
                    weight = table.Column<decimal>(type: "numeric", nullable: false),
                    details = table.Column<string>(type: "text", nullable: true),
                    slug = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "application",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    order_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    order_code = table.Column<string>(type: "text", nullable: false),
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    payment_status = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    tax_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    shipping_fee = table.Column<decimal>(type: "numeric", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_personalization_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "application",
                        principalTable: "personalization_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "role_claim",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claim_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "application",
                        principalTable: "role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_claim",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claim_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "application",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_login",
                schema: "application",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_login", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_user_login_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "application",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                schema: "application",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_role", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_role_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "application",
                        principalTable: "role",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_role_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "application",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                schema: "application",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_token", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_user_token_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "application",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "images",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_name = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_main_image = table.Column<bool>(type: "boolean", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_images", x => x.id);
                    table.ForeignKey(
                        name: "fk_images_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "application",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_colors",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    color_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    colors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_colors", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_colors_colors_colors_id",
                        column: x => x.colors_id,
                        principalSchema: "application",
                        principalTable: "colors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_colors_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "application",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_fabrics",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fabric_material = table.Column<string>(type: "text", nullable: false),
                    fabric_composition_percentage = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<int>(type: "integer", nullable: false),
                    shrinkage = table.Column<int>(type: "integer", nullable: false),
                    is_wrinkle_resistant = table.Column<bool>(type: "boolean", nullable: true),
                    is_antibacterial = table.Column<bool>(type: "boolean", nullable: true),
                    is_uv_protection = table.Column<bool>(type: "boolean", nullable: true),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_fabrics", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_fabrics_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "application",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_forms",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    form_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_forms_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "application",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_inventories",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    size_id = table.Column<Guid>(type: "uuid", nullable: true),
                    color_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity_in_stock = table.Column<int>(type: "integer", nullable: false),
                    quantity_reserved = table.Column<int>(type: "integer", nullable: false),
                    quantity_sold = table.Column<int>(type: "integer", nullable: false),
                    low_stock_threshold = table.Column<int>(type: "integer", nullable: false),
                    enable_low_stock_alert = table.Column<bool>(type: "boolean", nullable: false),
                    last_restock_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_stock_out_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_inventories", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_inventories_colors_color_id",
                        column: x => x.color_id,
                        principalSchema: "application",
                        principalTable: "colors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_product_inventories_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "application",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_inventories_sizes_size_id",
                        column: x => x.size_id,
                        principalSchema: "application",
                        principalTable: "sizes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "shipping_addresses",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_line1 = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    province = table.Column<string>(type: "text", nullable: false),
                    ward = table.Column<string>(type: "text", nullable: false),
                    zip_code = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    email_address = table.Column<string>(type: "text", nullable: false),
                    shipping_note = table.Column<string>(type: "text", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipping_addresses", x => x.id);
                    table.ForeignKey(
                        name: "fk_shipping_addresses_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "application",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_sizes",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    size_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_color_id = table.Column<Guid>(type: "uuid", nullable: true),
                    sizes_id = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_sizes", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_sizes_product_colors_product_color_id",
                        column: x => x.product_color_id,
                        principalSchema: "application",
                        principalTable: "product_colors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_product_sizes_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "application",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_sizes_sizes_sizes_id",
                        column: x => x.sizes_id,
                        principalSchema: "application",
                        principalTable: "sizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accessories",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    original_price = table.Column<decimal>(type: "numeric", nullable: false),
                    accessory_category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accessories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accessory_categories",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    accessory_id = table.Column<Guid>(type: "uuid", nullable: true),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accessory_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_accessory_categories_accessories_accessory_id",
                        column: x => x.accessory_id,
                        principalSchema: "application",
                        principalTable: "accessories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "accessory_inventories",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    accessory_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity_in_stock = table.Column<int>(type: "integer", nullable: true),
                    color = table.Column<string>(type: "text", nullable: false),
                    last_stock_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accessory_inventories", x => x.id);
                    table.ForeignKey(
                        name: "fk_accessory_inventories_accessories_accessory_id",
                        column: x => x.accessory_id,
                        principalSchema: "application",
                        principalTable: "accessories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "cart_items",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: true),
                    color_id = table.Column<Guid>(type: "uuid", nullable: true),
                    size_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    accessory_id = table.Column<Guid>(type: "uuid", nullable: true),
                    item_type = table.Column<int>(type: "integer", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_cart_items_accessories_accessory_id",
                        column: x => x.accessory_id,
                        principalSchema: "application",
                        principalTable: "accessories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_cart_items_colors_color_id",
                        column: x => x.color_id,
                        principalSchema: "application",
                        principalTable: "colors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_cart_items_personalization_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "application",
                        principalTable: "personalization_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cart_items_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "application",
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_cart_items_sizes_size_id",
                        column: x => x.size_id,
                        principalSchema: "application",
                        principalTable: "sizes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: true),
                    accessory_id = table.Column<Guid>(type: "uuid", nullable: true),
                    color_id = table.Column<Guid>(type: "uuid", nullable: true),
                    size_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    original_price = table.Column<decimal>(type: "numeric", nullable: false),
                    colors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sizes_id = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_items_accessories_accessory_id",
                        column: x => x.accessory_id,
                        principalSchema: "application",
                        principalTable: "accessories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_order_items_colors_colors_id",
                        column: x => x.colors_id,
                        principalSchema: "application",
                        principalTable: "colors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "application",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_items_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "application",
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_order_items_sizes_sizes_id",
                        column: x => x.sizes_id,
                        principalSchema: "application",
                        principalTable: "sizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_accessories_accessory_category_id",
                schema: "application",
                table: "accessories",
                column: "accessory_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_accessory_categories_accessory_id",
                schema: "application",
                table: "accessory_categories",
                column: "accessory_id");

            migrationBuilder.CreateIndex(
                name: "ix_accessory_inventories_accessory_id",
                schema: "application",
                table: "accessory_inventories",
                column: "accessory_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_accessory_id",
                schema: "application",
                table: "cart_items",
                column: "accessory_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_color_id",
                schema: "application",
                table: "cart_items",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_product_id",
                schema: "application",
                table: "cart_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_size_id",
                schema: "application",
                table: "cart_items",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_user_id",
                schema: "application",
                table: "cart_items",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_images_product_id",
                schema: "application",
                table: "images",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_accessory_id",
                schema: "application",
                table: "order_items",
                column: "accessory_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_colors_id",
                schema: "application",
                table: "order_items",
                column: "colors_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_order_id",
                schema: "application",
                table: "order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_product_id",
                schema: "application",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_items_sizes_id",
                schema: "application",
                table: "order_items",
                column: "sizes_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_user_id",
                schema: "application",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_colors_colors_id",
                schema: "application",
                table: "product_colors",
                column: "colors_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_colors_product_id",
                schema: "application",
                table: "product_colors",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_fabrics_product_id",
                schema: "application",
                table: "product_fabrics",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_forms_product_id",
                schema: "application",
                table: "product_forms",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_inventories_color_id",
                schema: "application",
                table: "product_inventories",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_inventories_product_id",
                schema: "application",
                table: "product_inventories",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_inventories_size_id",
                schema: "application",
                table: "product_inventories",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_sizes_product_color_id",
                schema: "application",
                table: "product_sizes",
                column: "product_color_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_sizes_product_id",
                schema: "application",
                table: "product_sizes",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_sizes_sizes_id",
                schema: "application",
                table: "product_sizes",
                column: "sizes_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                schema: "application",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "application",
                table: "role",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_role_claim_role_id",
                schema: "application",
                table: "role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipping_addresses_order_id",
                schema: "application",
                table: "shipping_addresses",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "application",
                table: "user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "application",
                table: "user",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_claim_user_id",
                schema: "application",
                table: "user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_login_user_id",
                schema: "application",
                table: "user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_role_role_id",
                schema: "application",
                table: "user_role",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_accessories_accessory_categories_accessory_category_id",
                schema: "application",
                table: "accessories",
                column: "accessory_category_id",
                principalSchema: "application",
                principalTable: "accessory_categories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accessories_accessory_categories_accessory_category_id",
                schema: "application",
                table: "accessories");

            migrationBuilder.DropTable(
                name: "accessory_inventories",
                schema: "application");

            migrationBuilder.DropTable(
                name: "application_logs",
                schema: "application");

            migrationBuilder.DropTable(
                name: "banners",
                schema: "application");

            migrationBuilder.DropTable(
                name: "cart_items",
                schema: "application");

            migrationBuilder.DropTable(
                name: "images",
                schema: "application");

            migrationBuilder.DropTable(
                name: "order_items",
                schema: "application");

            migrationBuilder.DropTable(
                name: "product_fabrics",
                schema: "application");

            migrationBuilder.DropTable(
                name: "product_forms",
                schema: "application");

            migrationBuilder.DropTable(
                name: "product_inventories",
                schema: "application");

            migrationBuilder.DropTable(
                name: "product_sizes",
                schema: "application");

            migrationBuilder.DropTable(
                name: "role_claim",
                schema: "application");

            migrationBuilder.DropTable(
                name: "shipping_addresses",
                schema: "application");

            migrationBuilder.DropTable(
                name: "user_claim",
                schema: "application");

            migrationBuilder.DropTable(
                name: "user_login",
                schema: "application");

            migrationBuilder.DropTable(
                name: "user_role",
                schema: "application");

            migrationBuilder.DropTable(
                name: "user_token",
                schema: "application");

            migrationBuilder.DropTable(
                name: "product_colors",
                schema: "application");

            migrationBuilder.DropTable(
                name: "sizes",
                schema: "application");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "application");

            migrationBuilder.DropTable(
                name: "role",
                schema: "application");

            migrationBuilder.DropTable(
                name: "user",
                schema: "application");

            migrationBuilder.DropTable(
                name: "colors",
                schema: "application");

            migrationBuilder.DropTable(
                name: "products",
                schema: "application");

            migrationBuilder.DropTable(
                name: "personalization_users",
                schema: "application");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "application");

            migrationBuilder.DropTable(
                name: "accessory_categories",
                schema: "application");

            migrationBuilder.DropTable(
                name: "accessories",
                schema: "application");
        }
    }
}
