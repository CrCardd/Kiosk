using Microsoft.Extensions.DependencyInjection; 
using Kiosk.Domain.Services;
using System.Reflection;

namespace Kiosk.Application.Config; 

public static class ServiceExtensions 
{ 
        public static void ConfigureServices(this IServiceCollection services) 
    { 
        // 1. Forçar o carregamento de todas as DLLs do projeto "Kiosk" que estão na pasta
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var assemblies = Directory.GetFiles(path, "Kiosk.*.dll")
            .Select(Assembly.LoadFrom)
            .ToList();

        // Inclui o assembly atual também (onde estão as extensões)
        assemblies.Add(Assembly.GetExecutingAssembly());

        // 2. Buscar todas as interfaces que herdam de IBaseService
        var allTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();

        var interfaces = allTypes
            .Where(t => t.IsInterface && typeof(IBaseService).IsAssignableFrom(t) && t != typeof(IBaseService))
            .ToList(); 

        foreach(var iservice in interfaces) 
        { 
            // 3. Achar a classe que implementa essa interface
            var implementation = allTypes
                .FirstOrDefault(t => t.IsClass && !t.IsAbstract && iservice.IsAssignableFrom(t)); 
                
            if (implementation != null)
            {
                services.AddTransient(iservice, implementation); 
            }
        } 
    }
}