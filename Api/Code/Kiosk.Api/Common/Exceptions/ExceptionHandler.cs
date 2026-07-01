using Kiosk.Api.Controllers.Api;
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
        var (statusCode, message) = exception switch
        {
            BadRequestEx => (StatusCodes.Status400BadRequest, exception.Message),
            ConflictEx => (StatusCodes.Status409Conflict, exception.Message),
            ForbiddenEx => (StatusCodes.Status403Forbidden, exception.Message),
            ImATeapotEx => (StatusCodes.Status418ImATeapot, exception.Message),
            InternalServerErrorEx => (StatusCodes.Status500InternalServerError, exception.Message),
            NotFoundEx => (StatusCodes.Status404NotFound, exception.Message),
            NotImplementedEx => (StatusCodes.Status501NotImplemented, exception.Message),
            UnauthorizedEx => (StatusCodes.Status401Unauthorized, exception.Message),
            
            _ => (
                StatusCodes.Status500InternalServerError, 
                $"""
                method was not setted on ExceptionHandler.
                ${exception.Message}
                """
            )
        };

        httpContext.Response.StatusCode = statusCode;

        var response = new ApiResponse<bool>
        {
            Ok = false,
            Value = false,
            Message = message
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}