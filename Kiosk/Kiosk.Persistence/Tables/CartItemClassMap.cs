
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class CartItemClassMap
{
    public static void ConfigureCartItemTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<CartItem>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(cartitem => cartitem.Id)
            .HasName("cartitem_id");

        builder.ToTable("tb_cartitem");

        //================PROPERTIES================
        builder.Property(ci => ci.SnapShotPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        //================MY-RELATIONS================
        builder.HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId);
        builder.HasOne(ci => ci.Variant)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId);
        //================RELATIONS================
        builder.HasMany(ci => ci.Ingredients)
            .WithMany(i => i.CartItems)
            .UsingEntity(
                "CartItemIngredient",
                r => r.HasOne(typeof(Ingredient)).WithMany().HasForeignKey("IngredientsId").HasPrincipalKey(nameof(Ingredient.Id)),
                l => l.HasOne(typeof(CartItem)).WithMany().HasForeignKey("CartItemsId").HasPrincipalKey(nameof(CartItem.Id)),
                j => j.HasKey("IngredientsId", "CartItemsId")
            );
    
    });
}
