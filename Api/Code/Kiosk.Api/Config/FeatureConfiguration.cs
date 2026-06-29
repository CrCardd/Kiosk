using Kiosk.Application.Features;
using Kiosk.Application.Services;
using Kiosk.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kiosk.Application.Config; 

public static class FeatureConfiguration 
{ 
    public static void ConfigureFeatures(this IServiceCollection services) 
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        
        var assemblies = Directory.GetFiles(path, "Kiosk.*.dll")
            .Select(Assembly.LoadFrom)
            .ToList();

        assemblies.Add(Assembly.GetExecutingAssembly());

        var allTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();

        var features = allTypes
            .Where(t => t.IsClass && !t.IsAbstract && typeof(BaseFeature).IsAssignableFrom(t))
            .ToList();

        foreach(var feature in features)
            services.AddScoped(feature);
    }
}