
using Kiosk.Domain.Models;
using Kiosk.Persistence.Tables;
using Microsoft.EntityFrameworkCore;
//using Kiosk.Persistence.Tables;

namespace Kiosk.Persistence.Context;

public class KioskContext(DbContextOptions<KioskContext> options) : DbContext(options)
{
    public DbSet<Cart> Carts {get;set;}
    public DbSet<CartItem> CartItems {get;set;}
    public DbSet<Ingredient> Ingredients {get;set;}
    public DbSet<Order> Orders {get;set;}
    public DbSet<PriceHistoryIngredient> PriceHistoryIngredients {get;set;}
    public DbSet<PriceHistoryVariant> PriceHistoryVariants {get;set;}
    public DbSet<Service> Services {get;set;}
    public DbSet<Variant> Variants {get;set;}
    public DbSet<VariantIngredient> VariantIngredients {get;set;}
    //public DbSet<_> _s {get;set;}

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCartTable();
        modelBuilder.ConfigureCartItemTable();
        modelBuilder.ConfigureIngredientTable();
        modelBuilder.ConfigureOrderTable();
        modelBuilder.ConfigurePriceHistoryIngredientTable();
        modelBuilder.ConfigurePriceHistoryVariantTable();
        modelBuilder.ConfigureServiceTable();
        modelBuilder.ConfigureVariantTable();
        modelBuilder.ConfigureCombinationTable();
        modelBuilder.ConfigureVariantIngredientTable();
        // modelBuilder.Configur();

        base.OnModelCreating(modelBuilder);
    }
}
