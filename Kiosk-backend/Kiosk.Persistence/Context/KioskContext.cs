
using Kiosk.Persistence.Tables;
using Microsoft.EntityFrameworkCore;
//using Kiosk.Persistence.Tables;

namespace Kiosk.Persistence.Context;

public class KioskContext(DbContextOptions<KioskContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureIngredientTable();
        modelBuilder.ConfigureOrderTable();
        modelBuilder.ConfigurePriceTable();
        modelBuilder.ConfigureProductIngredientTable();
        modelBuilder.ConfigureProductOrderTable();
        modelBuilder.ConfigureProductTable();
        modelBuilder.ConfigureServiceTable();
        modelBuilder.ConfigureTokenTable();

        base.OnModelCreating(modelBuilder);
    }
}
