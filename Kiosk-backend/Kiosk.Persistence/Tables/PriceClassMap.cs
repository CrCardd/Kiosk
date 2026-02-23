
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class PriceClassMap
{
    public static void ConfigurePriceTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Price>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(price => price.Id)
            .HasName("price_id");

        builder.ToTable("tb_price");

        //================PROPERTIES================
        builder.Property(p => p.Value)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(p => p.Product)
            .WithMany(p => p.Prices)
            .HasForeignKey(p => p.ProductId);
    });
}
