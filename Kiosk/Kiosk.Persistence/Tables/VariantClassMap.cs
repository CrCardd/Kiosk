
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class VariantClassMap
{
    public static void ConfigureVariantTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Variant>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(variant => variant.Id)
            .HasName("variant_id");

        builder.ToTable("tb_variant");

        //================PROPERTIES================
        builder.Property(v => v.Name)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(v => v.Image)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(v => v.Ingredients);
        builder.Property(v => v.Surpass);
        builder.Property(v => v.Available)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(v => v.Service)
            .WithMany(s => s.Variants)
            .HasForeignKey(v => v.ServiceId);
        //================RELATIONS================
        builder.HasMany(v => v.CartItems)
            .WithOne(ci => ci.Variant)
            .HasForeignKey(ci => ci.VariantId)
            .IsRequired();        
        builder.HasMany(v => v.PriceHistoryVariants)
            .WithOne(phv => phv.Variant)
            .HasForeignKey(phv => phv.VariantId)
            .IsRequired();      
        builder.HasMany(v => v.Combs)
            .WithOne(c => c.Comb)
            .HasForeignKey(c => c.CombId)
            .IsRequired();  
        builder.HasMany(v => v.Parts)
            .WithOne(c => c.Part)
            .HasForeignKey(c => c.PartId)
            .IsRequired();
        builder.HasMany(i => i.VariantIngredients)
            .WithOne(vi => vi.Variant)
            .HasForeignKey(vi => vi.VariantId)
            .IsRequired();
    });
}
