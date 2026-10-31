
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class OAuthProviderClassMap
{
    public static void ConfigureOAuthProviderTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<OAuthProviderModel>(builder =>
    {
        builder.ConfigureBaseTableProps();
        builder.HasKey(order => order.Id)
            .HasName("oauth_provider_id");
        builder.ToTable("tb_oauth_provider");
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
        //================RELATIONS================
    });
}
