
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Kiosk.Application.Config;

namespace Kiosk.Infrastructure.Context;


public class KioskDbContextFactory : IDesignTimeDbContextFactory<KioskContext>
{
    public KioskContext CreateDbContext(string[] args)
    {
        DotEnv.Load();

        var optionsBuilder = new DbContextOptionsBuilder<KioskContext>();

        var connection = DotEnv.Get("DATABASE_URL");
        var source = "Data Source=" + connection;
        optionsBuilder.UseSqlite(source);

        return new KioskContext(optionsBuilder.Options);
    }
}
