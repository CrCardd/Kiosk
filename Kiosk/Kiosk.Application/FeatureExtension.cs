using System.Reflection;
using Kiosk.Application.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Kiosk.Application;

public static class FeatureExtension
{
    public static void ConfigureFeatures(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var features = assembly.GetTypes()
            .Where(t => 
                t.IsClass && !t.IsAbstract 
                && typeof(BaseFeature).IsAssignableFrom(t)
            ) 
            .ToList();

        foreach(var feature in features)
            services.AddTransient(feature);
        
    }
}