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
                    Client = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SessionToken = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
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
                    Quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Ingredients = table.Column<int>(type: "INTEGER", nullable: false),
                    Surpass = table.Column<bool>(type: "INTEGER", nullable: false),
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
                name: "tb_cartitem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SnapShotPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "TEXT", nullable: true),
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
                        name: "FK_tb_cartitem_tb_cartitem_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "tb_cartitem",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_cartitem_tb_variant_VariantId",
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
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
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
                name: "tb_variantingredient",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
                    VariantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IngredientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    disabled_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("variantingredient_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_variantingredient_tb_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "tb_ingredient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_variantingredient_tb_variant_VariantId",
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
                name: "IX_tb_cartitem_ReferenceId",
                table: "tb_cartitem",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cartitem_VariantId",
                table: "tb_cartitem",
                column: "VariantId");

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
                name: "IX_tb_pricehistoryingredient_IngredientId",
                table: "tb_pricehistoryingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pricehistoryvariant_VariantId",
                table: "tb_pricehistoryvariant",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variant_ServiceId",
                table: "tb_variant",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variantingredient_IngredientId",
                table: "tb_variantingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_variantingredient_VariantId",
                table: "tb_variantingredient",
                column: "VariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemIngredient");

            migrationBuilder.DropTable(
                name: "tb_combination");

            migrationBuilder.DropTable(
                name: "tb_order");

            migrationBuilder.DropTable(
                name: "tb_pricehistoryingredient");

            migrationBuilder.DropTable(
                name: "tb_pricehistoryvariant");

            migrationBuilder.DropTable(
                name: "tb_variantingredient");

            migrationBuilder.DropTable(
                name: "tb_cartitem");

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
