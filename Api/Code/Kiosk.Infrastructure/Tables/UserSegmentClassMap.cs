using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class UserSegmentClassMap
{
    public static void ConfigureUserSegmentTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<UserSegmentModel>(builder =>
    {
        builder.ConfigureBaseTableProps();
        builder.HasKey(order => order.Id)
            .HasName("user_segment_id");
        builder.ToTable("tb_user_segment");
        //================PROPERTIES================
        builder.Property(us => us.Roles)
            .HasColumnName("roles")
            .IsRequired();
        //================MY-RELATIONS================
        builder.Property(us => us.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        builder.HasOne(us => us.User)
            .WithMany(u => u.UserSegments)
            .HasForeignKey(us => us.UserId);
        builder.Property(us => us.SegmentId)
            .HasColumnName("segment_id")
            .IsRequired();
        builder.HasOne(us => us.Segment)
            .WithMany(s => s.UserSegments)
            .HasForeignKey(us => us.SegmentId);
        //================RELATIONS================
    });
}