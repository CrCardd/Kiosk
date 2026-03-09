
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class CartClassMap
{
    public static void ConfigureCartTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Cart>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(cart => cart.Id)
            .HasName("cart_id");

        builder.ToTable("tb_cart");

        
        //================PROPERTIES================
        builder.Property(c => c.Client)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(c => c.SessionToken)
            .HasMaxLength(255)
            .IsRequired();
        //================MY-RELATIONS================
        
        //================RELATIONS================
        builder.HasOne(c => c.Order)
            .WithOne(o => o.Cart)
            .HasForeignKey<Order>(o => o.CartId)
            .IsRequired();
    
    });
}
