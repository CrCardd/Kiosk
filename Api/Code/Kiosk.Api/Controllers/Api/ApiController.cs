using Kiosk.Application.Common.Enums;
using Kiosk.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Api.Controllers.Api;

public abstract class ApiController : ControllerBase
{
    protected ActionResult HandleResult<T>(Result<T> result)
    {
        var response = new ApiResponse<T>
        {
            Ok = result.IsSuccess,
            Message = result.Message,
            Value = result.Value,
        };

        return result.Status switch
        {
            Status.Ok => Ok(response),
            
            Status.BadRequest => BadRequest(response),
            Status.Conflict => Conflict(response),
            Status.Forbidden => StatusCode(StatusCodes.Status403Forbidden, response),
            Status.ImATeapot => StatusCode(StatusCodes.Status418ImATeapot, response),
            Status.InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, response),
            Status.NotFound => NotFound(response),
            Status.NotImplemented => StatusCode(StatusCodes.Status501NotImplemented, response),
            Status.Unauthorized => Unauthorized(response),

            _ => StatusCode(StatusCodes.Status500InternalServerError, "method was not setted on HandleResult (ApiController)")
            
        };
    }
}