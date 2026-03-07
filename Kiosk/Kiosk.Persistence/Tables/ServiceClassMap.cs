
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class ServiceClassMap
{
    public static void ConfigureServiceTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Service>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(service => service.Id)
            .HasName("service_id");

        builder.ToTable("tb_service");

        //================PROPERTIES================
        builder.Property(s => s.Name)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(s => s.Image)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(s => s.Available)
            .IsRequired();
        //================MY-RELATIONS================
        
        //================RELATIONS================
        builder.HasMany(s => s.Variants)
            .WithOne(v => v.Service)
            .HasForeignKey(v => v.ServiceId);
        builder.HasMany(s => s.Ingredients)
            .WithOne(i => i.Service)
            .HasForeignKey(i => i.ServiceId);
    
    });
}
