
using Kiosk.Persistence.Tables;
using Microsoft.EntityFrameworkCore;
//using Kiosk.Persistence.Tables;

namespace Kiosk.Persistence.Context;

public class KioskContext(DbContextOptions<KioskContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCartTable();
        modelBuilder.ConfigureCartItemTable();
        modelBuilder.ConfigureIngredientTable();
        modelBuilder.ConfigureOrderTable();
        modelBuilder.ConfigurePriceHistoryIngredientTable();
        modelBuilder.ConfigurePriceHistoryProductTable();
        modelBuilder.ConfigurePriceHistoryVariantTable();
        modelBuilder.ConfigureProductTable();
        modelBuilder.ConfigureServiceTable();
        modelBuilder.ConfigureVariantTable();
        // modelBuilder.Configur();

        base.OnModelCreating(modelBuilder);
    }
}
