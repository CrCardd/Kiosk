
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class OrderClassMap
{
    public static void ConfigureOrderTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Order>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(order => order.Id)
            .HasName("order_id");

        builder.ToTable("tb_order");

        //================PROPERTIES================
        builder.Property(o => o.Code)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(o => o.Index)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(o => o.Total)
            .HasPrecision(18,2)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(o => o.Cart)
            .WithOne(c => c.Order)
            .HasForeignKey<Order>(o => o.CartId);
        //================RELATIONS================
    
    });
}
