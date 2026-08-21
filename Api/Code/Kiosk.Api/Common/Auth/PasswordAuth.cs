using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Api.Controllers.Api;
using Kiosk.Domain.Common.Exceptions;

namespace Kiosk.Api.Common.Auth;

public class PasswordAuthAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        TokenType role = TokenType.Password;

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