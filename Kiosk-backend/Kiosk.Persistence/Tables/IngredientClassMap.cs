
using System.Drawing;
using System.Net.NetworkInformation;
using Kiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Persistence.Tables;

public static class IngredientClassMap
{
    public static void ConfigureIngredientTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Ingredient>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(ingredient => ingredient.Id)
            .HasName("ingredient_id");

        builder.ToTable("tb_ingredient");

        //================PROPERTIES================
        builder.Property(i => i.Name)
            .HasMaxLength(255)
            .IsRequired();

        //================MY-RELATIONS================

        //================RELATIONS================
        builder.HasMany(i => i.ProductIngredients)
            .WithOne(pi => pi.Ingredient)
            .HasForeignKey(pi => pi.IngredientId);
    });
}
