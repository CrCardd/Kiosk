
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class IngredientClassMap
{
    public static void ConfigureIngredientTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Ingredient>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(ingredient => ingredient.Id)
            .HasName("ingredient_id");

        builder.ToTable("tb_ingredient");

        //================PROPERTIES================
        builder.Property(i => i.Name)
            .HasMaxLength(255)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(i => i.Service)
            .WithMany(s => s.Ingredients)
            .HasForeignKey(i => i.ServiceId);
        //================RELATIONS================
        builder.HasMany(i => i.PriceHistoryIngredients)
            .WithOne(phi => phi.Ingredient)
            .HasForeignKey(phi => phi.IngredientId);
        builder.HasMany(i => i.CartItems)
            .WithMany(ci => ci.Ingredients)
            .UsingEntity(
                "CartItemIngredient",
                r => r.HasOne(typeof(CartItem)).WithMany().HasForeignKey("CartItemsId").HasPrincipalKey(nameof(CartItem.Id)),
                l => l.HasOne(typeof(Ingredient)).WithMany().HasForeignKey("IngredientsId").HasPrincipalKey(nameof(Ingredient.Id)),
                j => j.HasKey("CartItemsId","IngredientsId")
            );
    
    });
}
