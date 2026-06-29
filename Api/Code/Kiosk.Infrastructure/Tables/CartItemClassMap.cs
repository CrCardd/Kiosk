
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class CartItemClassMap
{
    public static void ConfigureCartItemTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<CartItemModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(cartitem => cartitem.Id)
            .HasName("cart_item_id");

        builder.ToTable("tb_cart_item");

        //================PROPERTIES================
        builder.Property(ci => ci.SnapShotPrice)
            .HasPrecision(18, 2)
            .HasColumnName("snapshot_price")
            .IsRequired();
        //================MY-RELATIONS================        
        builder.Property(ci => ci.CartId)
            .HasColumnName("cart_id")
            .IsRequired();
        builder.HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId)
            .IsRequired();
        
        builder.Property(ci => ci.ReferenceId)
            .HasColumnName("reference_id")
            .IsRequired();
        builder.HasOne(ci => ci.Reference)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.ReferenceId);
        
        builder.Property(ci => ci.VariantId)
            .HasColumnName("variant_id")
            .IsRequired();
        builder.HasOne(ci => ci.Variant)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.VariantId);

        //================RELATIONS================
        builder.HasMany(ci => ci.Ingredients)
            .WithMany(i => i.CartItems)
            .UsingEntity(
                "tb_cart_item_ingredient",
                r => r.HasOne(typeof(IngredientModel)).WithMany().HasForeignKey("IngredientsId").HasPrincipalKey(nameof(IngredientModel.Id)),
                l => l.HasOne(typeof(CartItemModel)).WithMany().HasForeignKey("CartItemsId").HasPrincipalKey(nameof(CartItemModel.Id)),
                j => j.HasKey("IngredientsId", "CartItemsId")
            );
        builder.HasMany(ci => ci.CartItems)
            .WithOne(ci => ci.Reference)
            .HasForeignKey(ci => ci.ReferenceId);
    });
}
