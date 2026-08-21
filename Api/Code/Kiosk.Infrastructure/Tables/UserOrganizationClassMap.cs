using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class UserOrganizationClassMap
{
    public static void ConfigureUserOrganizationTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<UserOrganizationModel>(builder =>
    {
        builder.ConfigureBaseTableProps();
        builder.HasKey(order => order.Id)
            .HasName("user_organization_id");
        builder.ToTable("tb_user_organization");
        //================PROPERTIES================
        builder.Property(uo => uo.Roles)
            .HasColumnName("roles")
            .IsRequired();
        //================MY-RELATIONS================
        builder.Property(uo => uo.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        builder.HasOne(us => us.User)
            .WithMany(u => u.UserOrganizations)
            .HasForeignKey(uo => uo.UserId);
        builder.Property(uo => uo.OrganizationId)
            .HasColumnName("organization_id")
            .IsRequired();
        builder.HasOne(uo => uo.Organization)
            .WithMany(s => s.UserOrganizations)
            .HasForeignKey(uo => uo.OrganizationId);
        //================RELATIONS================
    });
}