using Kiosk.Api.Controllers.Api;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Common.Exceptions;
using Kiosk.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kiosk.Api.Common.Auth;

public class BaseAuth(TokenType type, TokenPurpose purpose) : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var httpContext = context.HttpContext;
        if (httpContext.User?.Identity == null || !httpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new JsonResult(new ApiResponse { Ok = false, Message = "User not authenticated or invalid token" })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
            return;
        }
        var apiCtx = httpContext.RequestServices.GetRequiredService<IApiContext>();

        var isAuthorized = apiCtx.TokenType == type && apiCtx.TokenPurpose == purpose;

        
        if (!isAuthorized)
        {
            context.Result = new JsonResult(new ApiResponse{Ok = false, Message = $"Missing type {type.ToMyString()} or purpose {purpose.ToMyString()}"})
            {
                StatusCode = Status.Forbidden.Code()
            };
        }
    }
}