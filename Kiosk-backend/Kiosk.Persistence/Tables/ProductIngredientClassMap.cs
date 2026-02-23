
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class ProductIngredientClassMap
{
    public static void ConfigureProductIngredientTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<ProductIngredient>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(productingredient => productingredient.Id)
            .HasName("productingredient_id");

        builder.ToTable("tb_productingredient");

        //================PROPERTIES================
        builder.Property(pi => pi.Weight);
        //================MY-RELATIONS================
        builder.HasOne(pi => pi.Product)
            .WithMany(p => p.ProductIngredients)
            .HasForeignKey(pi => pi.ProductId);
        builder.HasOne(pi => pi.Ingredient)
            .WithMany(p => p.ProductIngredients)
            .HasForeignKey(pi => pi.IngredientId);
        //================RELATIONS================
        
    });
}
