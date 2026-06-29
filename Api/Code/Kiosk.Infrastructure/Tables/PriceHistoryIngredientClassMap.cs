
﻿using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Infrastructure.Tables;

public static class PriceHistoryIngredientClassMap
{
    public static void ConfigurePriceHistoryIngredientTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<PriceHistoryIngredientModel>(builder =>
    {
        builder.ConfigureBaseTableProps();

        builder.HasKey(pricehistoryingredient => pricehistoryingredient.Id)
            .HasName("price_history_ingredient_id");

        builder.ToTable("tb_price_history_ingredient");

        //================PROPERTIES================
        builder.Property(phi => phi.Price)
            .HasPrecision(18,2)
            .HasColumnName("price")
            .IsRequired();
        //================MY-RELATIONS================        
        builder.Property(phi => phi.IngredientId)
            .HasColumnName("ingredient_id")
            .IsRequired();
        builder.HasOne(phi => phi.Ingredient)
            .WithMany(i => i.PriceHistoryIngredients)
            .HasForeignKey(phi => phi.IngredientId)
            .IsRequired();
        //================RELATIONS================
    
    });
}
