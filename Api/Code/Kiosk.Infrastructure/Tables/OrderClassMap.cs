
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class OrderClassMap
{
    public static void ConfigureOrderTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<OrderModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(order => order.Id)
            .HasName("order_id");

        builder.ToTable("tb_order");

        //================PROPERTIES================
        builder.Property(o => o.Code)
            .HasMaxLength(255)
            .HasColumnName("code")
            .IsRequired();
        builder.Property(o => o.Index)
            .HasColumnName("index")
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(o => o.Total)
            .HasColumnName("total")
            .HasPrecision(18,2)
            .IsRequired();
        //================MY-RELATIONS================        
        builder.Property(o => o.CartId)
            .HasColumnName("cart_id")
            .IsRequired();
        builder.HasOne(o => o.Cart)
            .WithOne(c => c.Order)
            .HasForeignKey<OrderModel>(o => o.CartId)
            .IsRequired();
        //================RELATIONS================
    
    });
}
