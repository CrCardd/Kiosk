using Kiosk.Application.Config;
using Kiosk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kiosk.Infrastructure.Config;

public static class ConfigureDatabase
{
    public static void ConfigureDb(this IServiceCollection services)
    {
        DotEnv.Load();
        
        var connection = DotEnv.Get("DATABASE_URL");
        var source = "Data Source=" + connection;
        
        services.AddDbContext<KioskContext>(options =>
            options.UseSqlite(source)
        );
    }
}