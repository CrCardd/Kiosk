using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiosk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSet : Migration
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
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("order_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_cart_CartId",
                        column: x => x.CartId,
                        principalTable: "tb_cart",
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
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ingredient_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_ingredient_tb_service_ServiceId",
                        column: x => x.ServiceId,
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
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("variant_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_variant_tb_service_ServiceId",
                        column: x => x.ServiceId,
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
                    IngredientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("price_history_ingredient_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_price_history_ingredient_tb_ingredient_IngredientId",
                        column: x => x.IngredientId,
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
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "TEXT", nullable: true),
                    VariantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cart_item_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_cart_item_tb_cart_CartId",
                        column: x => x.CartId,
                        principalTable: "tb_cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_cart_item_tb_cart_item_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "tb_cart_item",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_cart_item_tb_variant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_combination",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CombId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("combination_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_combination_tb_variant_CombId",
                        column: x => x.CombId,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_combination_tb_variant_PartId",
                        column: x => x.PartId,
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
                    VariantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("price_history_variant_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_price_history_variant_tb_variant_VariantId",
                        column: x => x.VariantId,
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
                    VariantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IngredientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("variant_ingredient_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_variant_ingredient_tb_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "tb_ingredient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_variant_ingredient_tb_variant_VariantId",
                        column: x => x.VariantId,
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
                name: "IX_tb_cart_item_CartId",
                table: "tb_cart_item",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_item_ReferenceId",
                table: "tb_cart_item",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_item_VariantId",
                table: "tb_cart_item",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cart_item_ingredient_IngredientsId",
                table: "tb_cart_item_ingredient",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_combination_CombId",
                table: "tb_combination",
                column: "CombId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_combination_PartId",
                table: "tb_combination",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ingredient_ServiceId",
                table: "tb_ingredient",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_CartId",
                table: "tb_order",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_price_history_ingredient_IngredientId",
                table: "tb_price_history_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_price_history_variant_VariantId",
                table: "tb_price_history_variant",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variant_ServiceId",
                table: "tb_variant",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variant_ingredient_IngredientId",
                table: "tb_variant_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variant_ingredient_VariantId",
                table: "tb_variant_ingredient",
                column: "VariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cart_item_ingredient");

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
