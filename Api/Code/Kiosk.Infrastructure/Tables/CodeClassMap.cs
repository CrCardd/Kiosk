using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class CodeClassMap
{
    public static void ConfigureCodeTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<CodeModel>(builder =>
    {
        builder.ConfigureBaseWithSegmentTableProps();
        builder.HasKey(code => code.Id)
            .HasName("code_id");
        builder.ToTable("tb_code");
        //================PROPERTIES================
        builder.Property(c => c.Code)
            .HasColumnName("code")
            .IsRequired();
        builder.Property(c => c.StartDate)
            .HasColumnName("start_date")
            .IsRequired();
        builder.Property(c => c.EndDate)
            .HasColumnName("end_date")
            .IsRequired();
        //================MY-RELATIONS================
        builder.Property(c => c.SegmentId)
            .HasColumnName("segment_id")
            .IsRequired();
        builder.HasOne(c => c.Segment)
            .WithMany(c => c.Codes)
            .HasForeignKey(c => c.SegmentId);
        //================RELATIONS================
    });
}