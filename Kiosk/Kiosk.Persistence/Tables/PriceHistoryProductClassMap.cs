
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class PriceHistoryProductClassMap
{
    public static void ConfigurePriceHistoryProductTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<PriceHistoryProduct>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(pricehistoryproduct => pricehistoryproduct.Id)
            .HasName("pricehistoryproduct_id");

        builder.ToTable("tb_pricehistoryproduct");

        //================PROPERTIES================
        builder.Property(phi => phi.Price)
            .HasPrecision(18,2)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(php => php.Product)
            .WithMany(i => i.PriceHistoryProducts)
            .HasForeignKey(php => php.ProductId);
        //================RELATIONS================
    
    });
}
