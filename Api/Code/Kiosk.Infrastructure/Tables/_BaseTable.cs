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
}