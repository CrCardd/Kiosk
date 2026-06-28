using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class OrganizationClassMap
{
    public static void ConfigureOrganizationTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<OrganizationModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(order => order.Id)
            .HasName("organization_id");

        builder.ToTable("tb_organization");

        //================PROPERTIES================
        builder.Property(o => o.Name)
            .HasMaxLength(255)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(o => o.Password)
            .HasColumnName("password")
            .IsRequired();
        
        //================MY-RELATIONS================

        //================RELATIONS================
        builder.HasMany(o => o.Codes)
            .WithOne(c => c.Organization)
            .HasForeignKey(c => c.OrganizationId);
    });
}