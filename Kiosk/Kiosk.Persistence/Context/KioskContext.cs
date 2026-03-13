
using System.Collections;
using Kiosk.Domain.Models;
using Kiosk.Persistence.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public DbSet<Combination> Combinations {get;set;}
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {   
        foreach(var e in ChangeTracker.Entries<BaseModel>().Where(e => e.State == EntityState.Deleted))
            CascadeSoftDelete(e);
            
        return base.SaveChangesAsync(cancellationToken);
    }

    public void CascadeSoftDelete(EntityEntry entry)
    {
        entry.State = EntityState.Unchanged;
        ((BaseModel)entry.Entity).DisabledAt = DateTime.UtcNow;
        // Console.WriteLine("\n\n\n");
        // Console.WriteLine("!!!!!!!!!!!!!!!!!");
        // Console.WriteLine("");
        // Console.WriteLine("!!!!!!!!!!!!!!!!!");
        // foreach(var nav in entry.Navigations)
        //     if(nav.CurrentValue is IEnumerable children)
        //         foreach(var c in children)
        //             if(c is BaseModel bc)
        //             {
        //                 var entryC = Entry(bc);
        //                 CascadeSoftDelete(entryC);
        //             }
    }
}
