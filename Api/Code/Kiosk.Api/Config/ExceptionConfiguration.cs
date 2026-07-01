using Kiosk.Api.Common.Exceptions;

namespace Kiosk.Api.Config;

public static class ExceptionConfiguration
{
    public static void ConfigureException(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<ExceptionHandler>();
    }

    public static void ConfigureException(this WebApplication app)
    {
        app.UseExceptionHandler();
    }
}