using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiosk.Persistence.Migrations
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
                    SessionToken = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    OderId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
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
                    Client = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Index = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
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
                name: "tb_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_product_tb_service_ServiceId",
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
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
                name: "tb_pricehistoryingredient",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    IngredientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pricehistoryingredient_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pricehistoryingredient_tb_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "tb_ingredient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pricehistoryproduct",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pricehistoryproduct_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pricehistoryproduct_tb_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tb_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cartitem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SnapShotPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VariantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cartitem_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_cartitem_tb_cart_CartId",
                        column: x => x.CartId,
                        principalTable: "tb_cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_cartitem_tb_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tb_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_cartitem_tb_variant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pricehistoryvariant",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    VariantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pricehistoryvariant_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pricehistoryvariant_tb_variant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "tb_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItemIngredient",
                columns: table => new
                {
                    CartItemsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemIngredient", x => new { x.CartItemsId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_CartItemIngredient_tb_cartitem_CartItemsId",
                        column: x => x.CartItemsId,
                        principalTable: "tb_cartitem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItemIngredient_tb_ingredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "tb_ingredient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItemIngredient_IngredientsId",
                table: "CartItemIngredient",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cartitem_CartId",
                table: "tb_cartitem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cartitem_ProductId",
                table: "tb_cartitem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cartitem_VariantId",
                table: "tb_cartitem",
                column: "VariantId");

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
                name: "IX_tb_pricehistoryingredient_IngredientId",
                table: "tb_pricehistoryingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pricehistoryproduct_ProductId",
                table: "tb_pricehistoryproduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pricehistoryvariant_VariantId",
                table: "tb_pricehistoryvariant",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_ServiceId",
                table: "tb_product",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variant_ServiceId",
                table: "tb_variant",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemIngredient");

            migrationBuilder.DropTable(
                name: "tb_order");

            migrationBuilder.DropTable(
                name: "tb_pricehistoryingredient");

            migrationBuilder.DropTable(
                name: "tb_pricehistoryproduct");

            migrationBuilder.DropTable(
                name: "tb_pricehistoryvariant");

            migrationBuilder.DropTable(
                name: "tb_cartitem");

            migrationBuilder.DropTable(
                name: "tb_ingredient");

            migrationBuilder.DropTable(
                name: "tb_cart");

            migrationBuilder.DropTable(
                name: "tb_product");

            migrationBuilder.DropTable(
                name: "tb_variant");

            migrationBuilder.DropTable(
                name: "tb_service");
        }
    }
}
