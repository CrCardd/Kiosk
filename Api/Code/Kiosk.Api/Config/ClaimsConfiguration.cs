using System.Security.Claims;
using Kiosk.Api.Common.Exceptions;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Utils;

namespace Kiosk.Api.Config;

public static class ClaimsConfiguration
{
    public static Guid OrganizationId(this ClaimsPrincipal user)
    {
        var key = MyClaims.OrganizationId;
        var claim = user.FindFirst(key)?.Value;   
        if(claim is null)
            throw new Exception($"Claim [{key}] not found");
        return Guid.Parse(claim);
    }
    public static string Email(this ClaimsPrincipal user)
    {
        var key = MyClaims.Email;
        var claim = user.FindFirst(key)?.Value;   
        if(claim is null)
            throw new Exception($"Claim [{key}] not found");
        return claim;
    }
    public static Role Role(this ClaimsPrincipal user)
    {
        var key = MyClaims.Role;
        var claim = user.FindFirst(key)?.Value;   
        if(claim is null)
            throw new Exception($"Claim [{key}] not found");
        return Roles.GetRole(claim);
    }
}