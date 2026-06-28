using Kiosk.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kiosk.Application.Config; 

public static class ServiceExtensions 
{ 
        public static void ConfigureServices(this IServiceCollection services) 
    { 
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
            services.AddTransient(iservice, implementation); 
        } 
    }
}