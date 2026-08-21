using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Common.Exceptions;
using Kiosk.Api.Controllers.Api;

namespace Kiosk.Api.Common.Auth;

public class SessionAuthAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        TokenType role = TokenType.Session;

        var httpContext = context.HttpContext;
        if (httpContext.User?.Identity == null || !httpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        var apiCtx = httpContext.RequestServices.GetRequiredService<IApiContext>();

        var isAuthorized = apiCtx.TokenTypes.Any(r => r == role);

        
        if (!isAuthorized)
        {
            context.Result = new JsonResult(new ApiResponse{Ok = false, Message = $"Missing role {role.ToMyString()}"})
            {
                StatusCode = Status.Forbidden.Code()
            };
        }
    }
}