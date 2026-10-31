using Kiosk.Api.Controllers.Api;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions;
using Kiosk.Domain.Common.Exceptions.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Kiosk.Api.Common.Exceptions;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken
    )
    {
        Status status;
        string message;
        if(exception is BaseException ex)
        {
            (status, message) = (ex.Status, ex.Message);

            var logger = httpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogWarning(ex, "Domain Error: {Message}", message);
        }
        else
        {            
            (status, message) = (
                Status.InternalServerError, 
                "Method was not setted on ExceptionHandler. See the logs for further information."
            );

            var logger = httpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError(exception, "System Error");
        }

        httpContext.Response.StatusCode = status.Code();

        var response = new ApiResponse<bool?>
        {
            Ok = false,
            Value = null,
            Message = message
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}