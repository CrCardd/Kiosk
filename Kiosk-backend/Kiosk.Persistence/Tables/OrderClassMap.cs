
using Kiosk.Domain.Models;
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
        builder.Property(o => o.Client)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(o => o.Index)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(o => o.Code)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(o => o.Total)
            .IsRequired();
        //================MY-RELATIONS================

        //================RELATIONS================
        builder.HasMany(o => o.ProductOrders)
            .WithOne(po => po.Order)
            .HasForeignKey(po => po.OrderId);
    });
}
