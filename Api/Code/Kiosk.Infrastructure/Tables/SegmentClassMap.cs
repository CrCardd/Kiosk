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
        builder.HasMany(s => s.Carts)
            .WithOne(c => c.Segment)
            .HasForeignKey(c => c.SegmentId);
        builder.HasMany(s => s.Services)
            .WithOne(s => s.Segment)
            .HasForeignKey(s => s.SegmentId);
        builder.HasMany(s => s.Codes)
            .WithOne(c => c.Segment)
            .HasForeignKey(c => c.SegmentId);
        builder.HasMany(s => s.Ingredients)
            .WithOne(i => i.Segment)
            .HasForeignKey(i => i.SegmentId);
        builder.HasMany(s => s.Variants)
            .WithOne(v => v.Segment)
            .HasForeignKey(v => v.SegmentId);
        builder.HasMany(s => s.UserSegments)
            .WithOne(s => s.Segment)
            .HasForeignKey(s => s.SegmentId);
    });
}