
using System.Security.Authentication;
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class IngredientClassMap
{
    public static void ConfigureIngredientTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<IngredientModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(ingredient => ingredient.Id)
            .HasName("ingredient_id");

        builder.ToTable("tb_ingredient");

        //================PROPERTIES================
        builder.Property(i => i.Name)
            .HasMaxLength(255)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(i => i.Quantity)
            .HasColumnName("quantity");
        builder.Property(i => i.Available)
            .HasColumnName("available");
        //================MY-RELATIONS================        
        builder.Property(s => s.ServiceId)
            .HasColumnName("service_id")
            .IsRequired();
        builder.HasOne(i => i.Service)
            .WithMany(s => s.Ingredients)
            .HasForeignKey(i => i.ServiceId)
            .IsRequired();
        //================RELATIONS================
        builder.HasMany(i => i.PriceHistoryIngredients)
            .WithOne(phi => phi.Ingredient)
            .HasForeignKey(phi => phi.IngredientId);
        builder.HasMany(i => i.CartItems)
            .WithMany(ci => ci.Ingredients)
            .UsingEntity(
                "tb_cart_item_ingredient",
                r => r.HasOne(typeof(CartItemModel)).WithMany().HasForeignKey("CartItemsId").HasPrincipalKey(nameof(CartItemModel.Id)),
                l => l.HasOne(typeof(IngredientModel)).WithMany().HasForeignKey("IngredientsId").HasPrincipalKey(nameof(IngredientModel.Id)),
                j => j.HasKey("CartItemsId","IngredientsId")
            );
        builder.HasMany(i => i.VariantIngredients)
            .WithOne(vi => vi.Ingredient)
            .HasForeignKey(vi => vi.IngredientId)
            .IsRequired();
    
    });
}
