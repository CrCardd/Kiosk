using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kiosk.Infrastructure.Config;

public static class ConfigureDatabase
{
    public static void ConfigureDb(this IServiceCollection service)
    {        
        service.AddDbContext<KioskContext>(options =>
        {
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var dtbs = Environment.GetEnvironmentVariable("DB_NAME");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var pass = Environment.GetEnvironmentVariable("DB_PASS");
            
            var conn = $"Server={host};Port={port};Database={dtbs};Uid={user};Pwd={pass};";
            options.UseMySql(conn, new MySqlServerVersion(new Version(8, 0, 0)));
        });
    }
}