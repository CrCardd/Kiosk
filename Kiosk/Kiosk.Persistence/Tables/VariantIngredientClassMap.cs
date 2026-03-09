
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class VariantIngredientClassMap
{
    public static void ConfigureVariantIngredientTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<VariantIngredient>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(order => order.Id)
            .HasName("variantingredient_id");

        builder.ToTable("tb_variantingredient");

        //================PROPERTIES================
        builder.Property(vi => vi.Available)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(vi => vi.Ingredient)
            .WithMany(i => i.VariantIngredients)
            .HasForeignKey(vi => vi.IngredientId)
            .IsRequired();
        builder.HasOne(vi => vi.Variant)
            .WithMany(i => i.VariantIngredients)
            .HasForeignKey(vi => vi.VariantId)
            .IsRequired();
        //================RELATIONS================
    
    });
}
