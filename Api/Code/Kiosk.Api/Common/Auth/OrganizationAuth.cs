using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Kiosk.Domain.Utils;
using Kiosk.Application.Common.Enums;

namespace Kiosk.Api.Common.Auth;

public class OrganizationAuthAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        
        if (user?.Identity == null || !user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult(); 
            return;
        }

        var roleName = Roles.GetRoleName(Role.Organization);
        var hasRole = user.Claims
            .Any(c => 
                c.Type == MyClaims.Role && 
                c.Value == roleName
            );

        
        if (!hasRole)
            context.Result = new ForbidResult(); 
    }
}