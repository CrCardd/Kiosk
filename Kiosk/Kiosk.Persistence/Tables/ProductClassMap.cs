
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class ProductClassMap
{
    public static void ConfigureProductTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Product>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(product => product.Id)
            .HasName("product_id");

        builder.ToTable("tb_product");

        //================PROPERTIES================
        builder.Property(p => p.Name)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(p => p.Quantity)
            .IsRequired();
        builder.Property(p => p.Available)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(p => p.Service)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.ServiceId);
        //================RELATIONS================
        builder.HasMany(p => p.CartItems)
            .WithOne(ci => ci.Product)
            .HasForeignKey(ci => ci.ProductId);
        builder.HasMany(p => p.PriceHistoryProducts)
            .WithOne(phi => phi.Product)
            .HasForeignKey(phi => phi.ProductId);
    
    });
}
