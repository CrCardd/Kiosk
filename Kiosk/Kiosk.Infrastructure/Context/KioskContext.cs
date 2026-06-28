
using System.Collections;
using Kiosk.Domain.Models;
using Kiosk.Infrastructure.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kiosk.Infrastructure.Context;

public class KioskContext(DbContextOptions<KioskContext> options) : DbContext(options)
{
    public DbSet<CartModel> Carts {get;set;}
    public DbSet<CartItemModel> CartItems {get;set;}
    public DbSet<IngredientModel> Ingredients {get;set;}
    public DbSet<OrderModel> Orders {get;set;}
    public DbSet<PriceHistoryIngredientModel> PriceHistoryIngredients {get;set;}
    public DbSet<PriceHistoryVariantModel> PriceHistoryVariants {get;set;}
    public DbSet<ServiceModel> Services {get;set;}
    public DbSet<VariantModel> Variants {get;set;}
    public DbSet<VariantIngredientModel> VariantIngredients {get;set;}
    public DbSet<CombinationModel> Combinations {get;set;}
    public DbSet<CodeModel> Codes {get;set;}
    public DbSet<OrganizationModel> Organizations {get;set;}
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
        modelBuilder.ConfigureCodeTable();
        modelBuilder.ConfigureOrganizationTable();
        // modelBuilder.Configur();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {   
        var deleted = ChangeTracker
            .Entries<BaseModel>()
            .Where(e => e.State == EntityState.Deleted)
            .ToList();
        foreach(var e in deleted)
        {
            e.Entity.DisabledAt = DateTime.UtcNow;
            e.State = EntityState.Modified;
            e.Property(x => x.DisabledAt).IsModified = true;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
