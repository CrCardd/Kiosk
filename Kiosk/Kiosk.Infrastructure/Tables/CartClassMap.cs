
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class CartClassMap
{
    public static void ConfigureCartTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<CartModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(cart => cart.Id)
            .HasName("cart_id");

        builder.ToTable("tb_cart");

        
        //================PROPERTIES================
        builder.Property(c => c.Client)
            .HasMaxLength(255)
            .HasColumnName("client")
            .IsRequired();
        builder.Property(c => c.SessionToken)
            .HasMaxLength(255)
            .HasColumnName("session_token")
            .IsRequired();
        //================MY-RELATIONS================
        
        //================RELATIONS================
        builder.HasOne(c => c.Order)
            .WithOne(o => o.Cart)
            .HasForeignKey<OrderModel>(o => o.CartId)
            .IsRequired();
    
    });
}
