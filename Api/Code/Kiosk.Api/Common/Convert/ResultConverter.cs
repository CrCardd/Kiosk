using Kiosk.Api.Controllers.Api;
using Kiosk.Application.Common.Enums;
using Kiosk.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kiosk.Api.Common.Convert;

public class ResultFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult && objectResult.Value is IResultBase result)
        {
            var response = new ApiResponse<object?> 
            { 
                Ok = result.IsSuccess, 
                Message = result.Message, 
                Value = result.Value 
            };

            context.Result = result.Status switch
            {
                Status.Ok => new OkObjectResult(response),
                Status.BadRequest => new BadRequestObjectResult(response),
                Status.NotFound => new NotFoundObjectResult(response),
                Status.Conflict => new ConflictObjectResult(response),
                Status.Unauthorized => new UnauthorizedObjectResult(response),
                _ => new ObjectResult(response) { StatusCode = 500 }
            };
        }
    }
}