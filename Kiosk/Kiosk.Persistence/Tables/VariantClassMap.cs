
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
        builder.Property(v => v.Available)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(v => v.Service)
            .WithMany(s => s.Variants)
            .HasForeignKey(v => v.ServiceId);
        //================RELATIONS================
        builder.HasMany(v => v.CartItems)
            .WithOne(ci => ci.Variant)
            .HasForeignKey(ci => ci.VariantId);        
        builder.HasMany(v => v.PriceHistoryVariants)
            .WithOne(phv => phv.Variant)
            .HasForeignKey(phv => phv.VariantId);        
    });
}
