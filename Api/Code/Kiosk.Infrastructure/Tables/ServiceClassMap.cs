
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class ServiceClassMap
{
    public static void ConfigureServiceTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<ServiceModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(service => service.Id)
            .HasName("service_id");

        builder.ToTable("tb_service");

        //================PROPERTIES================
        builder.Property(s => s.Name)
            .HasColumnName("name")
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(s => s.Image)
            .HasColumnName("image")
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(s => s.Available)
            .HasColumnName("available")
            .IsRequired();
        //================MY-RELATIONS================
        builder.Property(s => s.OrganizationId)
            .HasColumnName("organization_id")
            .IsRequired();
        builder.HasOne(s => s.Organization)
            .WithMany(o => o.Services)
            .HasForeignKey(s => s.OrganizationId);
        
        //================RELATIONS================
        builder.HasMany(s => s.Variants)
            .WithOne(v => v.Service)
            .HasForeignKey(v => v.ServiceId);
        builder.HasMany(s => s.Ingredients)
            .WithOne(i => i.Service)
            .HasForeignKey(i => i.ServiceId);
    
    });
}
