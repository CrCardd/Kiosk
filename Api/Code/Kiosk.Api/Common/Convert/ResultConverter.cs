using Kiosk.Api.Controllers.Api;
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

            context.Result = new ObjectResult(response) 
            { 
                StatusCode = (int)result.Status 
            };
        }
    }
}