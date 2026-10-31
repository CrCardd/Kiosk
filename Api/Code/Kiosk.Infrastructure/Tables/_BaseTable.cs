using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kiosk.Domain.Models;

namespace Kiosk.Infrastructure.Tables;

public static class BaseTableConfigurationExtensios
{
    public static void ConfigureBaseTableProps<T>(this EntityTypeBuilder<T> builder)
        where T : BaseModel
    {
        builder.Property(t => t.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(t => t.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(t => t.DisabledAt)
            .HasColumnName("disabled_at");
    }
    public static void ConfigureBaseWithSegmentTableProps<T>(this EntityTypeBuilder<T> builder)
        where T : BaseModelWithSegment
    {
        builder.ConfigureBaseTableProps();
        builder.Property(t => t.SegmentId)
            .HasColumnName("segment_id")
            .IsRequired();
        builder.HasOne(t => t.Segment)
            .WithMany()
            .HasForeignKey(t => t.SegmentId);
    }
    public static void ConfigureBaseWithOrganizationTableProps<T>(this EntityTypeBuilder<T> builder)
        where T : BaseModelWithOrganization
    {
        builder.ConfigureBaseTableProps();
        builder.Property(t => t.OrganizationId)
            .HasColumnName("organization_id")
            .IsRequired();
        builder.HasOne(t => t.Organization)
            .WithMany()
            .HasForeignKey(t => t.OrganizationId);
    }
}