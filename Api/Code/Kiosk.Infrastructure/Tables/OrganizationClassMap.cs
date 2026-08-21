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
        //================MY-RELATIONS================
        //================RELATIONS================
        builder.HasMany(o => o.Segments)
            .WithOne(c => c.Organization)
            .HasForeignKey(c => c.OrganizationId);
        builder.HasMany(o => o.UserOrganizations)
            .WithOne(uo => uo.Organization)
            .HasForeignKey(uo => uo.OrganizationId);
    });
}