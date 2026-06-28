
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class VariantIngredientClassMap
{
    public static void ConfigureVariantIngredientTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<VariantIngredientModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(order => order.Id)
            .HasName("variant_ingredient_id");

        builder.ToTable("tb_variant_ingredient");

        //================PROPERTIES================
        builder.Property(vi => vi.Available)
            .HasColumnName("available")
            .IsRequired();
        //================MY-RELATIONS================        
        builder.Property(vi => vi.IngredientId)
            .HasColumnName("ingredient_id")
            .IsRequired();
        builder.HasOne(vi => vi.Ingredient)
            .WithMany(i => i.VariantIngredients)
            .HasForeignKey(vi => vi.IngredientId)
            .IsRequired();
        
        builder.Property(vi => vi.VariantId)
            .HasColumnName("variant_id")
            .IsRequired();
        builder.HasOne(vi => vi.Variant)
            .WithMany(i => i.VariantIngredients)
            .HasForeignKey(vi => vi.VariantId)
            .IsRequired();
        //================RELATIONS================
    
    });
}
