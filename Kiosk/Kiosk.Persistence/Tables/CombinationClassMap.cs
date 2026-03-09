
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class CombinationClassMap
{
    public static void ConfigureCombinationTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Combination>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(combination => combination.Id)
            .HasName("combination_id");

        builder.ToTable("tb_combination");

        
        //================PROPERTIES================
        builder.Property(c => c.Available)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(c => c.Comb)
            .WithMany(v => v.Combs)
            .HasForeignKey(c => c.CombId)
            .IsRequired();
        builder.HasOne(c => c.Part)
            .WithMany(v => v.Parts)
            .HasForeignKey(c => c.PartId)
            .IsRequired();
        //================RELATIONS================

    });
}
