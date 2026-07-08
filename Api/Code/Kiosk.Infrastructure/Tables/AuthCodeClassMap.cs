using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class AuthCodeClassMap
{
    public static void ConfigureAuthCodeTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<AuthCodeModel>(builder =>
    {
        builder.ConfigureBaseTableProps();
        builder.HasKey(code => code.Id)
            .HasName("auth_code_id");
        builder.ToTable("tb_auth_code");
        //================PROPERTIES================
        builder.Property(c => c.Code)
            .HasColumnName("code")
            .IsRequired();
        builder.Property(c => c.Email)
            .HasColumnName("email")
            .IsRequired();
        builder.Property(c => c.StartDate)
            .HasColumnName("start_date")
            .IsRequired();
        builder.Property(c => c.EndDate)
            .HasColumnName("end_date")
            .IsRequired();
        //================MY-RELATIONS================
        //================RELATIONS================
    });
}