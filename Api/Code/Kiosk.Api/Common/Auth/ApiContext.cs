using System.Security.Claims;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Utils;

public class ApiContext(IHttpContextAccessor accessor) : IApiContext
{
    private HttpContext? HttpContext => accessor.HttpContext;
    private ClaimsPrincipal? User => HttpContext?.User;

    public Guid? OrganizationId => User?.FindFirst(MyClaims.OrganizationId) != null 
        ? Guid.Parse(User.FindFirst(MyClaims.OrganizationId)!.Value) 
        : null;

    public Guid? CartId => User?.FindFirst(MyClaims.OrganizationId) != null 
        ? Guid.Parse(User.FindFirst(MyClaims.OrganizationId)!.Value) 
        : null;

    public string? Email => User?.FindFirst(MyClaims.Email)?.Value;

    public List<Role> Roles => User != null && User.HasClaim(c => c.Type == MyClaims.Roles)
        ? User.FindAll(MyClaims.Roles).Select(c => Kiosk.Domain.Common.Enums.Roles.GetRole(c.Value)).ToList()
        : new List<Role>();
}