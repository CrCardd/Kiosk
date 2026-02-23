
using Kiosk.Domain.Models;
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
        builder.Property(p => p.Available)
            .IsRequired();
        builder.Property(p => p.Quantity)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(p => p.Service)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.ServiceId);
        //================RELATIONS================
        builder.HasMany(p => p.ProductIngredients)
            .WithOne(pi => pi.Product)
            .HasForeignKey(p => p.ProductId);
        builder.HasMany(p => p.ProductOrders)
            .WithOne(po => po.Product)
            .HasForeignKey(p => p.ProductId);
        builder.HasMany(p => p.Prices)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);

    });
}
