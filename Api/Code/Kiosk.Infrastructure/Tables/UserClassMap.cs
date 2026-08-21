using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class UserClassMap
{
    public static void ConfigureUserTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<UserModel>(builder =>
    {
        builder.ConfigureBaseTableProps();
        builder.HasKey(order => order.Id)
            .HasName("user_id");
        builder.ToTable("tb_user");
        //================PROPERTIES================
        builder.Property(u => u.Name)
            .HasMaxLength(255)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(u => u.Email)
            .HasMaxLength(255)
            .HasColumnName("email")
            .IsRequired();
        builder.Property(u => u.Password)
            .HasMaxLength(255)
            .HasColumnName("password")
            .IsRequired();
        //================MY-RELATIONS================
        //================RELATIONS================
        builder.HasMany(u => u.UserSegments)
            .WithOne(us => us.User)
            .HasForeignKey(us => us.UserId);
        builder.HasMany(u => u.UserOrganizations)
            .WithOne(uo => uo.User)
            .HasForeignKey(uo => uo.UserId);
    });
}