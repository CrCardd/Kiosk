
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class PriceHistoryVariantClassMap
{
    public static void ConfigurePriceHistoryVariantTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<PriceHistoryVariantModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(pricehistoryvariant => pricehistoryvariant.Id)
            .HasName("price_history_variant_id");

        builder.ToTable("tb_price_history_variant");

        //================PROPERTIES================
        builder.Property(phi => phi.Price)
            .HasColumnName("price")
            .HasPrecision(18,2)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(phv => phv.Variant)
            .WithMany(i => i.PriceHistoryVariants)
            .HasForeignKey(phv => phv.VariantId)
            .IsRequired();
        //================RELATIONS================
    
    });
}