
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Kiosk.Domain.Services;

namespace Kiosk.Application;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
// 1. IMPORTANTE: Pegue o Assembly onde o ICartService/CartService moram.
    // Se eles estiverem no projeto Domain, use typeof(IBaseService).Assembly
    var domainAssembly = typeof(IBaseService).Assembly;

    // 2. Buscamos todas as CLASSES que implementam IBaseService
    var classesConcretas = domainAssembly.GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract && typeof(IBaseService).IsAssignableFrom(t))
        .ToList();

    foreach (var implementationType in classesConcretas)
    {
        // 3. Descobrimos qual é a interface específica (ex: ICartService)
        // Ignoramos a IBaseService genérica e pegamos a que herda dela
        var serviceInterface = implementationType.GetInterfaces()
            .FirstOrDefault(i => i != typeof(IBaseService) && typeof(IBaseService).IsAssignableFrom(i));

        if (serviceInterface != null)
        {
            // Registra o par: ICartService -> CartService
            services.AddTransient(serviceInterface, implementationType);
        }
        else
        {
            // Caso a classe não tenha uma interface específica, registra ela mesma
            services.AddTransient(implementationType);
        }        
    }
    }
}
