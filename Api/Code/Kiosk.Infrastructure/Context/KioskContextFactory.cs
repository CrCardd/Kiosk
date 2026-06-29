
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kiosk.Infrastructure.Context;


public class KioskDbContextFactory : IDesignTimeDbContextFactory<KioskContext>
{
    public KioskContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<KioskContext>();

        var host = Environment.GetEnvironmentVariable("DB_HOST");
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var dtbs = Environment.GetEnvironmentVariable("DB_NAME");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var pass = Environment.GetEnvironmentVariable("DB_PASS");
        
        var conn = $"Server={host};Port={port};Database={dtbs};Uid={user};Pwd={pass};";
        optionsBuilder.UseMySql(conn, new MySqlServerVersion(new Version(8, 0, 0)));

        return new KioskContext(optionsBuilder.Options);
    }
}
