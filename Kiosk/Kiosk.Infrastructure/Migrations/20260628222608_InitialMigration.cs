using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiosk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cart",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    client = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    session_token = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cart_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_organization",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("organization_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_service",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    image = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    available = table.Column<bool>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("service_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    index = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    total = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    cart_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("order_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_cart_cart_id",
                        column: x => x.cart_id,
                        principalTable: "tb_cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_code",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    organization_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("code_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_code_tb_organization_organization_id",
                        column: x => x.organization_id,
                        principalTable: "tb_organization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_ingredient",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    available = table.Column<bool>(type: "INTEGER", nullable: false),
                    service_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ingredient_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_ingredient_tb_service_service_id",
                        column: x => x.service_id,
                        principalTable: "tb_service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_variant",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ingredients = table.Column<int>(type: "INTEGER", nullable: false),
                    surpass = table.Column<bool>(type: "INTEGER", nullable: false),
                    available = table.Column<bool>(type: "INTEGER", nullable: false),
                    service_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("variant_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_variant_tb_service_service_id",
                        column: x => x.service_id,
                        principalTable: "tb_service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_price_history_ingredient",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    ingredient_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("price_history_ingredient_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_price_history_ingredient_tb_ingredient_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "tb_ingredient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cart_item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    snapshot_price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    cart_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    reference_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    variant_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cart_item_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_cart_item_tb_cart_cart_id",
                        column: x => x.cart_id,
                        principalTable: "tb_cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_cart_item_tb_cart_item_reference_id",
                        column: x => x.reference_id,
                        principalTable: "tb_cart_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_cart_item_tb_variant_variant_id",
                        column: x => x.variant_id,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_combination",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    comb_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    part_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("combination_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_combination_tb_variant_comb_id",
                        column: x => x.comb_id,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_combination_tb_variant_part_id",
                        column: x => x.part_id,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_price_history_variant",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    variant_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("price_history_variant_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_price_history_variant_tb_variant_variant_id",
                        column: x => x.variant_id,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_variant_ingredient",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    available = table.Column<bool>(type: "INTEGER", nullable: false),
                    variant_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ingredient_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("variant_ingredient_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_variant_ingredient_tb_ingredient_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "tb_ingredient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_variant_ingredient_tb_variant_variant_id",
                        column: x => x.variant_id,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cart_item_ingredient",
                columns: table => new
                {
                    CartItemsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cart_item_ingredient", x => new { x.CartItemsId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_tb_cart_item_ingredient_tb_cart_item_CartItemsId",
                        column: x => x.CartItemsId,
                        principalTable: "tb_cart_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_cart_item_ingredient_tb_ingredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "tb_ingredient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_item_cart_id",
                table: "tb_cart_item",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_item_reference_id",
                table: "tb_cart_item",
                column: "reference_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_item_variant_id",
                table: "tb_cart_item",
                column: "variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_item_ingredient_IngredientsId",
                table: "tb_cart_item_ingredient",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_code_organization_id",
                table: "tb_code",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_combination_comb_id",
                table: "tb_combination",
                column: "comb_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_combination_part_id",
                table: "tb_combination",
                column: "part_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ingredient_service_id",
                table: "tb_ingredient",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_cart_id",
                table: "tb_order",
                column: "cart_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_price_history_ingredient_ingredient_id",
                table: "tb_price_history_ingredient",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_price_history_variant_variant_id",
                table: "tb_price_history_variant",
                column: "variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variant_service_id",
                table: "tb_variant",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variant_ingredient_ingredient_id",
                table: "tb_variant_ingredient",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variant_ingredient_variant_id",
                table: "tb_variant_ingredient",
                column: "variant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cart_item_ingredient");

            migrationBuilder.DropTable(
                name: "tb_code");

            migrationBuilder.DropTable(
                name: "tb_combination");

            migrationBuilder.DropTable(
                name: "tb_order");

            migrationBuilder.DropTable(
                name: "tb_price_history_ingredient");

            migrationBuilder.DropTable(
                name: "tb_price_history_variant");

            migrationBuilder.DropTable(
                name: "tb_variant_ingredient");

            migrationBuilder.DropTable(
                name: "tb_cart_item");

            migrationBuilder.DropTable(
                name: "tb_organization");

            migrationBuilder.DropTable(
                name: "tb_ingredient");

            migrationBuilder.DropTable(
                name: "tb_cart");

            migrationBuilder.DropTable(
                name: "tb_variant");

            migrationBuilder.DropTable(
                name: "tb_service");
        }
    }
}
