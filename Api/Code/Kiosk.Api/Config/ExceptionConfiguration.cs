using Kiosk.Api.Common.Exceptions;

namespace Kiosk.Api.Config;

public static class ExceptionConfiguration
{
    public static void ConfigureException(this WebApplicationBuilder builder)
    {
        builder.Services.AddProblemDetails();
        builder.Services.AddExceptionHandler<ExceptionHandler>();

        builder.Logging.AddFilter("Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware", LogLevel.None);
    }

    public static void ConfigureException(this WebApplication app)
    {
        app.UseExceptionHandler();
    }
}