
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class ProviderClassMap
{
    public static void ConfigureProviderTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<ProviderModel>(builder =>
    {
        builder.ConfigureBaseTableProps();
        builder.HasKey(order => order.Id)
            .HasName("provider_id");
        builder.ToTable("tb_provider");
        //================PROPERTIES================
        builder.Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(p => p.Email)
            .HasColumnName("email")
            .IsRequired();
        builder.Property(p => p.Subject)
            .HasColumnName("subject")
            .IsRequired();
        builder.Property(p => p.Picture)
            .HasColumnName("picture")
            .IsRequired();
        builder.Property(p => p.Type)
            .HasColumnName("type")
            .IsRequired();
        //================MY-RELATIONS================        
        builder.Property(p => p.OrganizationId)
            .HasColumnName("organization_id")
            .IsRequired();
        builder.HasOne(p => p.Organization)
            .WithMany(p => p.Providers)
            .HasForeignKey(o => o.OrganizationId);
        //================RELATIONS================
    });
}
