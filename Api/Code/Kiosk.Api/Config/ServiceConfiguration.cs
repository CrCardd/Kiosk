using Kiosk.Domain.Interfaces;
using Kiosk.Infrastructure.Context;
using System.Reflection;

namespace Kiosk.Application.Config; 

public static class ServiceConfiguration 
{ 
    public static void ConfigureServices(this WebApplicationBuilder builder) 
    {
        builder.Services.AddTransient<SeedService>();

        var path = AppDomain.CurrentDomain.BaseDirectory;
        var assemblies = Directory.GetFiles(path, "Kiosk.*.dll")
            .Select(Assembly.LoadFrom)
            .ToList();

        assemblies.Add(Assembly.GetExecutingAssembly());

        var allTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();

        var interfaces = allTypes
            .Where(t => t.IsInterface && typeof(IBaseService).IsAssignableFrom(t) && t != typeof(IBaseService))
            .ToList(); 

        foreach(var iservice in interfaces) 
        { 
            var implementation = allTypes
                .First(t => t.IsClass && !t.IsAbstract && iservice.IsAssignableFrom(t));     
            builder.Services.AddTransient(iservice, implementation); 
        } 
    }
}