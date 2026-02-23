
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class ProductOrderClassMap
{
    public static void ConfigureProductOrderTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<ProductOrder>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(productorder => productorder.Id)
            .HasName("productorder_id");

        builder.ToTable("tb_productorder");

        //================PROPERTIES================
        builder.Property(po => po.SnapshotPrice)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(po => po.Order)
            .WithMany(o => o.ProductOrders)
            .HasForeignKey(o => o.OrderId);
        builder.HasOne(po => po.Product)
            .WithMany(o => o.ProductOrders)
            .HasForeignKey(o => o.ProductId);
        //================RELATIONS================
    });
}
