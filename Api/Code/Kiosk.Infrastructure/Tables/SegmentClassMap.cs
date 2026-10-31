using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class SegmentClassMap
{
    public static void ConfigureSegmentTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<SegmentModel>(builder =>
    {
        builder.ConfigureBaseTableProps();
        builder.HasKey(order => order.Id)
            .HasName("segment_id");
        builder.ToTable("tb_segment");
        //================PROPERTIES================
        builder.Property(s => s.Name)
            .HasMaxLength(255)
            .HasColumnName("name")
            .IsRequired();
        //================MY-RELATIONS================
        builder.Property(s => s.OrganizationId)
            .HasColumnName("organization_id");
        builder.HasOne(s => s.Organization)
            .WithMany(s => s.Segments)
            .HasForeignKey(s => s.OrganizationId);
        //================RELATIONS================
        
    });
}