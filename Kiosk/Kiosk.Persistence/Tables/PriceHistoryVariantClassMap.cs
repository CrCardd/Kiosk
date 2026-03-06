
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class PriceHistoryVariantClassMap
{
    public static void ConfigurePriceHistoryVariantTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<PriceHistoryVariant>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(pricehistoryvariant => pricehistoryvariant.Id)
            .HasName("pricehistoryvariant_id");

        builder.ToTable("tb_pricehistoryvariant");

        //================PROPERTIES================
        builder.Property(phi => phi.Price)
            .HasPrecision(18,2)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(phv => phv.Variant)
            .WithMany(i => i.PriceHistoryVariants)
            .HasForeignKey(phv => phv.VariantId);
        //================RELATIONS================
    
    });
}
