using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Kiosk.Domain.Common.Enums;
using Kiosk.Domain.Interfaces;
using Kiosk.Domain.Utils;

public class ApiContext(IHttpContextAccessor accessor) : IApiContext
{
    private HttpContext? HttpContext => accessor.HttpContext;
    private ClaimsPrincipal? User => HttpContext?.User;

    public Guid? UserId => User?.FindFirst(MyClaims.UserId) != null 
        ? Guid.Parse(User.FindFirst(MyClaims.UserId)!.Value) 
        : null;

    public Guid? CartId => User?.FindFirst(MyClaims.CartId) != null 
        ? Guid.Parse(User.FindFirst(MyClaims.CartId)!.Value) 
        : null;

    public string? Email => User?.FindFirst(MyClaims.Email)?.Value;

    public TokenType TokenType => TokenTypes.GetTokenType(User?.FindFirst(MyClaims.TokenType)?.Value ?? string.Empty);
    public TokenPurpose TokenPurpose => TokenPurposes.GetTokenPurpose(User?.FindFirst(MyClaims.TokenPurpose)?.Value ?? string.Empty);

    public Guid? SegmentId => User?.FindFirst(MyClaims.SegmentId) != null 
        ? Guid.Parse(User.FindFirst(MyClaims.SegmentId)!.Value) 
        : null;

    public Guid? OrganizationId => User?.FindFirst(MyClaims.OrganizationId) != null 
        ? Guid.Parse(User.FindFirst(MyClaims.OrganizationId)!.Value) 
        : null;

    public SegmentRole? SegmentRoles => User?.FindFirst(MyClaims.SegmentRoles) != null 
        ? (SegmentRole)int.Parse(User.FindFirst(MyClaims.SegmentRoles)!.Value) 
        : null;

    public OrganizationRole? OrganizationRoles => User?.FindFirst(MyClaims.OrganizationRoles) != null 
        ? (OrganizationRole)int.Parse(User.FindFirst(MyClaims.OrganizationRoles)!.Value) 
        : null;
    
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            var exp = User?.FindFirst(JwtRegisteredClaimNames.Exp)?.Value;

            return long.TryParse(
                exp,
                NumberStyles.None,
                CultureInfo.InvariantCulture,
                out var unixSeconds
            )
                ? DateTimeOffset.FromUnixTimeSeconds(unixSeconds)
                : null;
        }
    }
}