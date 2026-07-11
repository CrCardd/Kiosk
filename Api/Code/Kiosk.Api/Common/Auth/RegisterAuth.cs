using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Domain.Utils;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Api.Controllers.Api;
using Kiosk.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Kiosk.Api.Common.Auth;

public class RegisterAuthAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        Role role = Role.Register;

        var httpContext = context.HttpContext;
        if (httpContext.User?.Identity == null || !httpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        var apiCtx = httpContext.RequestServices.GetRequiredService<IApiContext>();

        var isAuthorized = apiCtx.Roles.Any(r => r == role);

        
        if (!isAuthorized)
        {
            context.Result = new JsonResult(new ApiResponse{Ok = false, Message = $"Missing role {role.ToMyString()}"})
            {
                StatusCode = Status.Forbidden.Code()
            };
        }
    }
}