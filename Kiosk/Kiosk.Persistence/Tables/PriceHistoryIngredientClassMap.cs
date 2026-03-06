
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class PriceHistoryIngredientClassMap
{
    public static void ConfigurePriceHistoryIngredientTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<PriceHistoryIngredient>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(pricehistoryingredient => pricehistoryingredient.Id)
            .HasName("pricehistoryingredient_id");

        builder.ToTable("tb_pricehistoryingredient");

        //================PROPERTIES================
        builder.Property(phi => phi.Price)
            .HasPrecision(18,2)
            .IsRequired();
        //================MY-RELATIONS================
        builder.HasOne(phi => phi.Ingredient)
            .WithMany(i => i.PriceHistoryIngredients)
            .HasForeignKey(phi => phi.IngredientId);
        //================RELATIONS================
    
    });
}
