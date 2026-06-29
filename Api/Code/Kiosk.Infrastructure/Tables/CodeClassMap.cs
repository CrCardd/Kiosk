using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class CodeClassMap
{
    public static void ConfigureCodeTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<CodeModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(code => code.Id)
            .HasName("code_id");

        builder.ToTable("tb_code");

        //================PROPERTIES================
        builder.Property(c => c.Code)
            .HasMaxLength(9)
            .HasColumnName("code")
            .IsRequired();
        builder.Property(c => c.StartDate)
            .IsRequired();
        builder.Property(c => c.EndDate)
            .IsRequired();
        
        //================MY-RELATIONS================
        builder.Property(c => c.OrganizationId)
            .HasColumnName("organization_id")
            .IsRequired();
        builder.HasOne(c => c.Organization)
            .WithMany(c => c.Codes)
            .HasForeignKey(c => c.OrganizationId);

        //================RELATIONS================

    });
}